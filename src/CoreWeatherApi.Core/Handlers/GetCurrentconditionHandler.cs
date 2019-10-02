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
    public class GetCurrentConditionQuery : IRequest<CurrentConditionsDto>
    {
        public int Id { get; set; }
    }

    public class GetCurrentConditionQueryValidator : AbstractValidator<GetCurrentConditionQuery>
    {
        public GetCurrentConditionQueryValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public class GetCurrentConditionHandler : IRequestHandler<GetCurrentConditionQuery, CurrentConditionsDto>
    {
        private readonly ICurrentConditionsProvider _currentConditionsProvider;

        public GetCurrentConditionHandler(ICurrentConditionsProvider currentConditionsProvider)
        {
            _currentConditionsProvider = currentConditionsProvider;
        }
        public Task<CurrentConditionsDto> Handle(GetCurrentConditionQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_currentConditionsProvider.Get(request.Id));
        }
    }
}