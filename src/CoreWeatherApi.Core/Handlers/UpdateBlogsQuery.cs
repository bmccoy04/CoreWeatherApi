
using System.Threading;
using System.Threading.Tasks;
using CoreWeatherApi.Core.Entities;
using CoreWeatherApi.Core.Exceptions;
using CoreWeatherApi.Core.Interfaces;
using FluentValidation;
using MediatR;

namespace CoreWeatherApi.Core.Handlers
{
    public class UpdateBlogQuery : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateBlogQueryValidator : AbstractValidator<UpdateBlogQuery>
    {
        public UpdateBlogQueryValidator() {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).Length(0, 1);
        }
    }


    public class UpdateBlogHandler : IRequestHandler<UpdateBlogQuery, int>
    {
        private readonly IRepository _repository;

        public UpdateBlogHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(UpdateBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetById<Blog>(request.Id);

            if(blog == null)
                throw new ItemNotFoundException($"Can't find blog with id: {request.Id}");

            blog.Name = request.Name;

            _repository.Update<Blog>(blog);

            return Task.FromResult(blog.Id);
        }
    }

}
