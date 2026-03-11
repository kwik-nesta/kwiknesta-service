using Asp.Versioning;
using KwikNesta.Mediator.Cores.Abstractions;
using KwikNesta.Shared.Responses;
using KwikNesta.Shared.ServiceDTOs.Infra;
using KwikNesta.Shared.ServiceQueries.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KwikNestaGateway.API.Controllers.V1
{
    [Route("api/v{version:apiversion}/infra")]
    [ApiVersion("1.0")]
    [ApiController]
    public class InfraController : ControllerBase
    {
        private readonly IKNMediator _mediator;

        public InfraController(IKNMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get audit logs
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("audit/{entityId}")]
        [ProducesResponseType(typeof(PagedResponse<AuditLogResponseDto>), 200)]
        public async Task<IActionResult> GetPaged([FromRoute] string entityId, 
                                                [FromQuery] AuditLogClientQuery query)
        {
            return Ok(await _mediator.SendAsync(new AuditLogQuery
            {
                Page = query.Page,
                PageSize = query.PageSize,
                Action = query.Action,
                DomainId = entityId
            }));
        }
    }
}
