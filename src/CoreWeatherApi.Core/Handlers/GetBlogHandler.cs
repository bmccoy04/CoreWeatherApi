using AutoMapper;
using CoreWeatherApi.Core.Dtos;
using CoreWeatherApi.Core.Entities;
using CoreWeatherApi.Core.Exceptions;
using CoreWeatherApi.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWeatherApi.Core.Handlers
{
    public class GetBlogQuery : IRequest<BlogDto>
    {
        public GetBlogQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }

    public class GetBlogValidator : AbstractValidator<GetBlogQuery>
    {
        public GetBlogValidator() {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public class GetBlogHandler : IRequestHandler<GetBlogQuery, BlogDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetBlogHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BlogDto> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetById<Blog>(request.Id);
            
            if(blog == null)
                throw new ItemNotFoundException($"Can't find blog with id: {request.Id}");

            return Task.FromResult(
                    _mapper.Map<BlogDto>(blog));
        }
    }
}
