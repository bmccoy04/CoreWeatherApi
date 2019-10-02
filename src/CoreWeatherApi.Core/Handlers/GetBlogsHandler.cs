using AutoMapper;
using CoreWeatherApi.Core.Dtos;
using CoreWeatherApi.Core.Entities;
using CoreWeatherApi.Core.Interfaces;
using FluentValidation;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWeatherApi.Core.Handlers
{
    public class GetBlogsQuery : IRequest<IEnumerable<BlogDto>>
    {

    }

    public class GetBlogsQueryValidator : AbstractValidator<GetBlogsQuery>
    {
        public GetBlogsQueryValidator() {
        }
    }

    public class GetBlogsHandler : IRequestHandler<GetBlogsQuery, IEnumerable<BlogDto>>
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetBlogsHandler(IRepository repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<IEnumerable<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<IEnumerable<BlogDto>>(_repository.List<Blog>()));
        }

    }
}
