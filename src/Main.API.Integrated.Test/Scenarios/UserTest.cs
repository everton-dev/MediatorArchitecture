using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Main.API.Integrated.Test.Fixtures;
using Xunit;

namespace Main.API.Integrated.Test.Scenarios
{
    public class UserTest
    {
        private readonly TestContext _testContext;
        public UserTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task User_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/user/get/1");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAll_ValuesReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/user/GetAll");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_Get_ReturnsBadRequestResponse()
        {
            var response = await _testContext.Client.GetAsync("/user/get/XXX");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Values_Get_CorrectContentType()
        {
            var response = await _testContext.Client.GetAsync("/user/get/5");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }
    }
}