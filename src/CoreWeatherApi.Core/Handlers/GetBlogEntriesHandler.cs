using CoreWeatherApi.Core.Entities;
using CoreWeatherApi.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWeatherApi.Core.Handlers
{
    public class GetBlogEntriesHandler : IRequestHandler<GetBlogEntriesQuery, IEnumerable<Entry>>
    {
        private readonly IRepository _repository;

        public GetBlogEntriesHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Entry>> Handle(GetBlogEntriesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.List<Entry>().Where(x => x.BlogId == request.BlogId).AsEnumerable());
        }
    }

    public class GetBlogEntriesQuery : IRequest<IEnumerable<Entry>>
    {
        public int BlogId { get; set; }

        public GetBlogEntriesQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
