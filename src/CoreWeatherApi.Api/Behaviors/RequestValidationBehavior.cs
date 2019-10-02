using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Serilog;

namespace CoreWeatherApi.Api.Behaviors
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private IValidator<TRequest> _validators;
        private ILogger _logger;

        public RequestValidationBehavior(IValidator<TRequest> validators, ILogger logger)
        {
            _validators = validators;
            _logger = logger;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            // var failures = _validators
            //     .Select(x => x.Validate(context))
            //     .SelectMany(result => result.Errors)
            //     .Where(f => f != null)
            //     .ToList();
            var failures = _validators.Validate(request);
            _logger.Debug("---- validation handler called -----");
            if(!failures.IsValid)
            {
                _logger.Debug(failures.ToString());
                throw new ValidationException(failures.ToString());
            }

            return next();
        }
    }
}