using System.Threading;
using System.Threading.Tasks;
using CoreWeatherApi.Core.Entities;
using CoreWeatherApi.Core.Interfaces;
using FluentValidation;
using MediatR;

namespace CoreWeatherApi.Core.Handlers
{
    public class SaveBlogQuery : IRequest<int>
    {
        public string Name { get; set; }
    }
    public class SaveBlogQueryValidator : AbstractValidator<SaveBlogQuery>
    {
        public SaveBlogQueryValidator() {
            RuleFor(x => x.Name).Length(0, 1);
        }
    }


    public class SaveBlogHandler : IRequestHandler<SaveBlogQuery, int>
    {
        private readonly IRepository _repository;

        public SaveBlogHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(SaveBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = new Blog() {Id  = 0, Name = request.Name};

            blog = _repository.Add(blog);

            return Task.FromResult(blog.Id);
        }
    }

}
