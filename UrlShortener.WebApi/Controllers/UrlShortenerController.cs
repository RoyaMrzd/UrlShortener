using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Application.UrlShorteners.Commands.CreateUrlShortener;
using UrlShortener.Application.UrlShorteners.Queries;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IMediator mediator;

        public UrlShortenerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUrlShortenerCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<UrlShortenerListResultQuery>> GetAll()
        {
            var result = await mediator.Send(new UrlShortenerListRequestQuery());

            return base.Ok(result);
        }


    }

}
