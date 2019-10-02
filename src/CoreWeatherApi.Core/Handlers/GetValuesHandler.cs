using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWeatherApi.Core.Handlers
{
    public class GetValuesQuery : IRequest<IEnumerable<string>>
    {
    }

    public class GetValuesHandler : IRequestHandler<GetValuesQuery, IEnumerable<string>>
    {
        public Task<IEnumerable<string>> Handle(GetValuesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult((new string[] { "Bryan", "McCoy" }).AsEnumerable()); 
        }

    }
}