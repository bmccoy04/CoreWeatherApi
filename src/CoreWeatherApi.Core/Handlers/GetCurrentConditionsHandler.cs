using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoreWeatherApi.Core.Dtos;
using CoreWeatherApi.Core.Interfaces;
using FluentValidation;
using MediatR;

namespace CoreWeatherApi.Core.Handlers
{
    public class GetCurrentConditionsQuery : IRequest<IEnumerable<CurrentConditionsDto>>
    {

    }

    public class GetCurrentConditionsQueryValidator : AbstractValidator<GetCurrentConditionsQuery>
    {
        public GetCurrentConditionsQueryValidator() {}
    }

    public class GetCurrentConditionsHandler : IRequestHandler<GetCurrentConditionsQuery, IEnumerable<CurrentConditionsDto>>
    {
        private readonly ICurrentConditionsProvider _currentConditionsProvider;

        public GetCurrentConditionsHandler(ICurrentConditionsProvider currentConditionsProvider)
        {
            _currentConditionsProvider = currentConditionsProvider;
        }
        public Task<IEnumerable<CurrentConditionsDto>> Handle(GetCurrentConditionsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_currentConditionsProvider.Get());
        }
    }
}