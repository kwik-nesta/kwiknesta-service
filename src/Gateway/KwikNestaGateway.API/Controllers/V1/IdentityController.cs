using Asp.Versioning;
using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Extensions;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.Commands;
using KwikNestaIdentity.Application.DTOs;
using KwikNestaIdentity.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KwikNestaGateway.API.Controllers.V1
{
    [Route("api/v{version:apiversion}/identity")]
    [ApiVersion("1.0")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IKNMediator _mediator;

        public IdentityController(IKNMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Signs in users
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("auth/sign-in")]
        [ProducesResponseType(typeof(Response<LoginResponseDto>), 200)]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return Ok(await _mediator.SendAsync(command));
        }

        /// <summary>
        /// Signs up users
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("auth/sign-up")]
        [ProducesResponseType(typeof(Response<RegistrationDto>), 200)]
        public async Task<IActionResult> Register([FromBody] RegistrationCommand command)
        {
            return Ok(await _mediator.SendAsync(command));
        }

        /// <summary>
        /// Verify account
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("auth/verify")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public async Task<IActionResult> Verify([FromBody] AccountVerificationCommand command)
        {
            var result = await _mediator.SendAsync(command);
            return Ok(result);
        }

        /// <summary>
        /// Requests new OTP
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("auth/otp")]
        public async Task<IActionResult> RequestOtp([FromBody] ResendOtpCommand command)
        {
            var result = await _mediator.SendAsync(command);
            return Ok(result);
        }

        /// <summary>
        /// Get logged in user details
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("user/current")]
        [ProducesResponseType(typeof(Response<CurrentUserDto>), 200)]
        public async Task<IActionResult> Current()
        {
            var userId = HttpContext.User.GetLoggedInUserId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Forbid();
            }

            return Ok(await _mediator.SendAsync(new LoggedInUserQuery
            {
                UserId = userId
            }));
        }
    }
}