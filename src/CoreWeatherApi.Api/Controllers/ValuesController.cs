using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWeatherApi.Core.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeatherApi.Api.Controllers
{
    [Route("api/v1/values")]
    public class ValuesController : BaseApiV1Controller 
    {
        private IMediator _mediator;

        public ValuesController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return Ok(await _mediator.Send(new GetValuesQuery()));
//            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
