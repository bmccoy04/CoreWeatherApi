using CoreWeatherApi.Core.Entities;
using CoreWeatherApi.Core.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoreWeatherApi.Core.Handlers
{
    public class DeleteBlogQuery : IRequest<bool>
    {
        public int Id { get; set;  }

        public DeleteBlogQuery(int id)
        {
            Id = id;
        }

    }

    public class DeleteBlogValidator : AbstractValidator<DeleteBlogQuery>
    {
        public DeleteBlogValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public class DeleteBlogHandler : IRequestHandler<DeleteBlogQuery, bool>
    {
        private IRepository _repository;

        public DeleteBlogHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(DeleteBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetById<Blog>(request.Id);
            _repository.Delete<Blog>(blog);

            return Task.FromResult(true);
        }
    }
       
}
