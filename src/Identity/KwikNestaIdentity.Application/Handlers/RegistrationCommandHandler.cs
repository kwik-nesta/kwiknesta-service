using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Extensions;
using KwikNesta.Shared.Helpers;
using KwikNesta.Shared.Implementations;
using KwikNesta.Shared.Models.Settings;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.Commands;
using KwikNestaIdentity.Application.DTOs;
using KwikNestaIdentity.Application.Validations;
using KwikNestaIdentity.Domain.Entities;
using KwikNestaIdentity.Domain.Enums;
using KwikNestaIdentity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace KwikNestaIdentity.Application.Handlers
{
    public class RegistrationCommandHandler : IKNRequestHandler<RegistrationCommand, Response<RegistrationDto>>
    {
        private readonly List<ESystemRoles> _accpetedRoles = new List<ESystemRoles> { ESystemRoles.LandLord, ESystemRoles.Tenant };
        private const int OtpExpirationMinute = 10;
        private readonly IIdentityRepositoryManager _repository;
        private readonly UserManager<User> _userManager;
        private readonly IHostEnvironment _host;
        private readonly JwtSettings _jwtSettings;

        public RegistrationCommandHandler(IIdentityRepositoryManager repository,
                                        UserManager<User> userManager,
                                        IOptions<KNApplicationSettings> options,
                                        IHostEnvironment host)
        {
            _repository = repository;
            _userManager = userManager;
            _host = host;
            _jwtSettings = options.Value.Jwt;
        }

        public async Task<Response<RegistrationDto>> HandleAsync(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var validate = new RegistrationCommandValidator().Validate(request);
            if (!validate.IsValid)
            {
                return Response<RegistrationDto>.Fail(validate.Errors.FirstOrDefault()?.ErrorMessage ??
                    IdentityResponse.RegistrationFailed, 400);
            }

            if (!_accpetedRoles.Contains(request.Role))
            {
                return Response<RegistrationDto>.Fail(IdentityResponse.InvalidRegistrationRole, 401);
            }

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return Response<RegistrationDto>.Fail(IdentityResponse.UserExists, 409);
            }

            var user = InitializeUser(request);
            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
            {
                return Response<RegistrationDto>.Fail(createResult.Errors?.FirstOrDefault()?.Description ?? 
                    IdentityResponse.RegistrationFailed, 400);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, request.Role.GetDescription());
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return Response<RegistrationDto>.Fail(roleResult.Errors.FirstOrDefault()?.Description ??
                    IdentityResponse.RegistrationFailed, 400);
            }

            var otp = TokenHelper.GenerateOtp();
            var otpHash = TokenHelper.HashToken(otp, _jwtSettings.Key);
            var otpEntry = InitializeOtp(user.Id, otpHash);
            await _repository.OtpEntry.AddAsync(otpEntry);
            await _repository.SaveAsync();

            Notifications.SendEmail(user.Email!, IdentityResponse.AccountActivationSubject, 
                _host.GetOtpNotification(user.FirstName, 
                                        IdentityResponse.AccountActivationMessage, 
                                        otp, 
                                        IdentityResponse.AccountActivationSecurityNotice, 
                                        OtpExpirationMinute));
            return Response<RegistrationDto>.Ok(new RegistrationDto(user.Email!));
        }

        private User InitializeUser(RegistrationCommand command)
        {
            return new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                OtherName = command.MiddleName,
                Email = command.Email,
                PhoneNumber = ValidationHelper.NormalizeNumber(command.PhoneNumber),
                UserName = command.Email,
                Gender = command.Gender
            };
        }

        private OtpEntry InitializeOtp(string userId, string otpHash)
        {
            return new OtpEntry 
            {
                UserId = userId,
                OtpHash = otpHash,
                ExpiresAt = DateTime.UtcNow.AddMinutes(OtpExpirationMinute),
                Type = EOtpType.AccountVerification
            };
        }
    }
}