using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Helpers;
using KwikNesta.Shared.Models.Settings;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.Commands;
using KwikNestaIdentity.Domain.Entities;
using KwikNestaIdentity.Domain.Enums;
using KwikNestaIdentity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace KwikNestaIdentity.Application.Handlers
{
    public class AccountVerificationCommandHandler : IKNRequestHandler<AccountVerificationCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IIdentityRepositoryManager _repository;
        private readonly JwtSettings _jwtSettings;

        public AccountVerificationCommandHandler(UserManager<User> userManager,
                                                IIdentityRepositoryManager repository,
                                                IOptions<KNApplicationSettings> options)
        {
            _userManager = userManager;
            _repository = repository;
            _jwtSettings = options.Value.Jwt;
        }

        public async Task<Response<string>> HandleAsync(AccountVerificationCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Otp) || string.IsNullOrWhiteSpace(request.Email))
            {
                return Response<string>.Fail(IdentityResponse.InvalidRequest, 400);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Response<string>.Fail(IdentityResponse.UserNotFoundWithEmail, 404);
            }

            var hash = TokenHelper.HashToken(request.Otp, _jwtSettings.Key);
            var otpEntry = await _repository.OtpEntry
                .FirstOrDefault(o => o.UserId.Equals(user.Id) &&
                                    o.Type == EOtpType.AccountVerification &&
                                    o.OtpHash.Equals(hash));

            if (otpEntry == null)
            {
                return Response<string>.Fail(IdentityResponse.InvalidOtp, 404);
            }

            if (otpEntry.ExpiresAt < DateTime.UtcNow)
            {
                return Response<string>.Fail(IdentityResponse.OtpExpired, 403);
            }

            user.EmailConfirmed = true;
            user.LastUpdatedOn = DateTime.UtcNow;
            user.Status = EUserStatus.Active;
            await _userManager.UpdateAsync(user);
            
            _repository.OtpEntry.Remove(otpEntry);
            await _repository.SaveAsync();

            return Response<string>.Ok(IdentityResponse.AccountVerificationSuccessful);
        }
    }
}