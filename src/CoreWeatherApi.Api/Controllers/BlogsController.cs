using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWeatherApi.Core.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CoreWeatherApi.Core.Entities;
using CoreWeatherApi.Core.Interfaces;
using CoreWeatherApi.Core.Dtos;

namespace CoreWeatherApi.Api.Controllers
{
    public class BlogsController : BaseApiV1Controller 
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/v1/Blogs
        [HttpGet]
        [Produces(typeof(IEnumerable<BlogDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetBlogsQuery()));
        }

        // GET: api/Blogs/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetBlogQuery(id)));
        }

        // POST: api/Blogs
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveBlogQuery blogQuery)
        {
            return Ok(await _mediator.Send(blogQuery));
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateBlogQuery blogQuery)
        {
            return Ok(await _mediator.Send(blogQuery));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBlogQuery(id)));
        }

        [HttpGet("{id}/Entries")]
        public async Task<IActionResult> GetEntries(int id)
        {
            return Ok(await _mediator.Send(new GetBlogEntriesQuery(id)));
        }
    }
}
