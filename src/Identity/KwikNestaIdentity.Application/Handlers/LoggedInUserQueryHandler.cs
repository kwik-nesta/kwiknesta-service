using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.DTOs;
using KwikNestaIdentity.Application.Queries;
using KwikNestaIdentity.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace KwikNestaIdentity.Application.Handlers
{
    public class LoggedInUserQueryHandler : IKNRequestHandler<LoggedInUserQuery, Response<CurrentUserDto>>
    {
        private readonly UserManager<User> _userManager;

        public LoggedInUserQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<CurrentUserDto>> HandleAsync(LoggedInUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return Response<CurrentUserDto>.Fail(IdentityResponse.UserNotFoundWithId, 404);
            }

            return Response<CurrentUserDto>.Ok(MapDomain(user));
        }

        private CurrentUserDto MapDomain(User user)
        {
            return new CurrentUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.OtherName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Gender = user.Gender,
                Status = user.Status
            };
        }
    }
}