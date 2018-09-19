using Cabinet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests.Web {


    //WebApplicationFactory<TEntryPoint> is used to create a TestServer for the integration tests. 
    //TEntryPoint is the entry point class of the SUT, usually the Startup class.
    public class FrameworkTests : IClassFixture<WebApplicationFactory<Startup>> {

        private readonly WebApplicationFactory<Startup> _factory;

        public FrameworkTests(WebApplicationFactory<Startup> factory) {

            _factory = factory;
        }

        //https://blogs.msdn.microsoft.com/webdev/2018/03/05/asp-net-core-2-1-0-preview1-functional-testing-of-mvc-applications/


        [Theory]
        [InlineData("/")]
        [InlineData("/Index")]
        [InlineData("/About")]
        [InlineData("/Contact")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url) {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
