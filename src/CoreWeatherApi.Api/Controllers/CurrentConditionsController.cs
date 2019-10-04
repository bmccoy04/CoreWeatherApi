
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWeatherApi.Core.Dtos;
using CoreWeatherApi.Core.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeatherApi.Api.Controllers
{
    [Route("api/v1/current-conditions")]
    public class CurrentConditionsController : BaseApiV1Controller
    {
        private IMediator _mediator;

        public CurrentConditionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentConditionsDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetCurrentConditionsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentConditionsDto>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetCurrentConditionQuery() { Id = id }));
        }
    }
}
