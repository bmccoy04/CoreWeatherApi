using System;
using System.Net.Http;
using CoreWeatherApi.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CoreWeatherApi.IntegrationTests.Api
{
    public class BlogsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;

         public BlogsControllerTests(WebApplicationFactory<Startup> factory)
         {
             _client = factory.CreateClient();
         }

        [Fact]
        public async void GetBlogsSuccess()
        {
            var httpResponse = await _client.GetAsync("/api/v1/Blogs");
            
            Assert.True(httpResponse.IsSuccessStatusCode);
        }
    }
}