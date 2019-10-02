using System;
using CoreWeatherApi.Core.Handlers;
using Xunit;
using Moq;
using CoreWeatherApi.Core.Interfaces;
using CoreWeatherApi.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using AutoMapper;
using CoreWeatherApi.Core.Dtos;

namespace CoreWeatherApi.UnitTests.Handlers
{
    public class GetBlogsHandlerTests 
    {
        [Fact]
        public async Task HandlesReturnListSuccess()
        {
            var repo = new Mock<IRepository>();
            var logger = new Mock<ILogger>();
            var mapper = new Mock<IMapper>();
            var handler = new GetBlogsHandler(repo.Object, logger.Object, mapper.Object);
            var request = new GetBlogsQuery();
            var cancellationToken = new System.Threading.CancellationToken();

            var expected = new List<BlogDto>() {new BlogDto {Id = 1, Name="My Test Blog"}};

            repo.Setup(x => x.List<Blog>()).Returns(new List<Blog>() {new Blog {Id = 1, Name="My Test Blog"}});
            mapper.Setup(x => x.Map<IEnumerable<BlogDto>>(expected)).Returns(expected);

            var actual = await handler.Handle(request, cancellationToken);

            Assert.Equal(expected, actual);
        }
    }
}
