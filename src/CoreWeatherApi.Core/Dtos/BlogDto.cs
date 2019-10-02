using FluentValidation;

namespace CoreWeatherApi.Core.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class BlogDtoValidator : AbstractValidator<BlogDto>
    {
        public BlogDtoValidator() {
            RuleFor(x => x.Name).Length(0, 1);
        }
    }
}