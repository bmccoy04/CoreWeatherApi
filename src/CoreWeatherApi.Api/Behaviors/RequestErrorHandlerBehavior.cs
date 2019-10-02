
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
    public class RequestErrorHandlerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private ILogger _logger;

        public RequestErrorHandlerBehavior(ILogger logger)
        {
            _logger = logger;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return next();
            } 
            catch(Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw;  
            }
        }
    }
}