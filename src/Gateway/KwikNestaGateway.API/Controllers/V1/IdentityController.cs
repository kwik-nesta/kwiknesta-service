using Asp.Versioning;
using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Responses;
using KwikNestaIdentity.Application.Commands;
using KwikNestaIdentity.Application.DTOs;
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
    }
}