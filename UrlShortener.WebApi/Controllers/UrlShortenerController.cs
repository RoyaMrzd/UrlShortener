using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UrlShortener.Application.UrlShorteners.Commands.CreateUrlShortener;
using UrlShortener.Application.UrlShorteners.Commands.UrlShortenerAccessHistories;
using UrlShortener.Application.UrlShorteners.Queries;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<UrlShortenerController> _logger;
        public UrlShortenerController(IMediator mediator, ILogger<UrlShortenerController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUrlShortener command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<UrlShortenerAccessHistoryListResultQuery>> GetAll()
        {
            var result = await mediator.Send(new UrlShortenerAccessHistoryListRequestQuery());

            return base.Ok(result);
        }


        [HttpGet, Route("/{token}")]
        public async Task<ActionResult> UrlRedirect([FromRoute] string token)
        {
            var request = new UrlShortenerItemRequestQuery() { Token = token };
            var result = await mediator.Send(request);
           
            var requestHistory = new CreateUrlShortenerAccessHistory() { UrlShortenerEntityId = result.Id };
            await mediator.Send(requestHistory);

            return Redirect(result.ReturnUrl);
        }





    }

}
