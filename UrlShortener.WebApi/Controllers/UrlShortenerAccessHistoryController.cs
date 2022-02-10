using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Application.UrlShorteners.Queries;

namespace UrlShortener.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerAccessHistoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<UrlShortenerAccessHistoryController> _logger;
        public UrlShortenerAccessHistoryController(IMediator mediator, ILogger<UrlShortenerAccessHistoryController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<UrlShortenerAccessHistoryListResultQuery>> GetUrlShortenerAccessHistory([FromBody] UrlShortenerAccessHistoryListRequestQuery command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
       
    }
}
