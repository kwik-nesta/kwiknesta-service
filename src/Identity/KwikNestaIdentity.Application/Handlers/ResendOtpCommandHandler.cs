using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Helpers;
using KwikNesta.Shared.Implementations;
using KwikNesta.Shared.Models.Settings;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Domain.Entities;
using KwikNestaIdentity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using KwikNesta.Shared.Extensions;
using KwikNestaIdentity.Application.Validations;
using KwikNesta.Shared.ServiceCommands.Identity;
using KwikNesta.Shared.Models.Enumerations.Identity;

namespace KwikNestaIdentity.Application.Handlers
{
    public class ResendOtpCommandHandler : IKNRequestHandler<ResendOtpCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;
        private const int OtpExpirationMinute = 10;
        private readonly IIdentityRepositoryManager _repository;
        private readonly IHostEnvironment _host;
        private readonly JwtSettings _jwtSettings;

        public ResendOtpCommandHandler(UserManager<User> userManager,
                                    IIdentityRepositoryManager repository,
                                    IOptions<KNApplicationSettings> options,
                                    IHostEnvironment host)
        {
            _userManager = userManager;
            _repository = repository;
            _host = host;
            _jwtSettings = options.Value.Jwt;
        }

        public async Task<Response<string>> HandleAsync(ResendOtpCommand request, CancellationToken cancellationToken)
        {
            var validator = new OtpResendValidator().Validate(request);
            if (!validator.IsValid)
            {
                return Response<string>.Fail(validator.Errors.FirstOrDefault()?.ErrorMessage ?? 
                    IdentityResponse.InvalidRequest, 400);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
            {
                return Response<string>.Fail(IdentityResponse.UserNotFoundWithEmail, 404);
            }

            if (user.EmailConfirmed && request.Type == EOtpType.AccountVerification)
            {
                return Response<string>.Fail(IdentityResponse.UserAlreadyVerified, 403);
            }

            var existingOtpEntry = await _repository.OtpEntry
                .FirstOrDefault(o => o.UserId.Equals(user.Id) &&
                                    o.Type == request.Type);
            if (existingOtpEntry != null)
            {
                _repository.OtpEntry.Remove(existingOtpEntry);
            }

            var otp = TokenHelper.GenerateOtp();
            var otpHash = TokenHelper.HashToken(otp, _jwtSettings.Key);
            var otpEntry = InitializeOtp(user.Id, otpHash, request.Type);
            await _repository.OtpEntry.AddAsync(otpEntry);

            await _repository.SaveAsync();

            var (subject, body, securityMessage) = GetMessageDetails(request.Type);
            Notifications.SendEmail(user.Email!, subject,
                _host.GetOtpNotification(user.FirstName,
                                        body,
                                        otp,
                                        securityMessage,
                                        OtpExpirationMinute));
            return Response<string>.Ok(IdentityResponse.ActivationOtpSent);
        }

        private OtpEntry InitializeOtp(string userId, string otpHash, EOtpType type)
        {
            return new OtpEntry
            {
                UserId = userId,
                OtpHash = otpHash,
                ExpiresAt = DateTime.UtcNow.AddMinutes(OtpExpirationMinute),
                Type = type
            };
        }

        private (string subject,  string body, string securityMessage) GetMessageDetails(EOtpType type)
        {
            return type switch
            {
                EOtpType.AccountVerification => (IdentityResponse.AccountActivationSubject,
                                        IdentityResponse.AccountActivationMessage,
                                        IdentityResponse.AccountActivationSecurityNotice),
                EOtpType.PasswordReset => (IdentityResponse.PasswordResetSubject,
                                        IdentityResponse.PasswordResetMessage,
                                        IdentityResponse.PasswordResetSecurityNotice),
                EOtpType.AccountReactivation => (IdentityResponse.AccountReactivationSubject,
                                        IdentityResponse.AccountReactivationMessage,
                                        IdentityResponse.AccountReactivationSecurityNotice),
                _ => throw new NotImplementedException(),
            };
        }
    }
}