using Asp.Versioning;
using KwikNesta.Mediator.Hangfire.Abstractions;
using KwikNesta.Shared.Extensions;
using KwikNesta.Shared.Responses;
using KwikNesta.Shared.ServiceNotifications.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KwikNestaGateway.API.Controllers.V1.Infra
{
    [Route("api/v{version:apiversion}/infra/tools")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ToolsController(IKNBackgroundMediator bgMediator) : ControllerBase
    {
        private readonly IKNBackgroundMediator _bgMediator = bgMediator;

        /// <summary>
        /// Runs Location Dataload
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost("location-dataload")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public IActionResult RunLocationDataload()
        {
            _bgMediator.Publish(new MigrateCsDataNotification
            {
                LoggedInUserId = HttpContext.User.GetLoggedInUserId()!,
                LoggedInUserEmail = HttpContext.User.GetLoggedInUserEmail()!,
                LoggedInUserIpAddress = HttpContext.GetUserIp()
            });

            return Ok(Response<string>.Ok("Location Dataload started. You'll be notified once completed."));
        }
    }
}