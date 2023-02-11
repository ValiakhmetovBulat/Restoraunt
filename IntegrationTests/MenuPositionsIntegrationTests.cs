using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace IntegrationTests
{
    public class MenuPositionsIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _user;
        public MenuPositionsIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _user = factory.CreateClient();
        }

        [Fact]
        public async Task Create_When_Called_ReturnsCreateFrom()
        {
            var responce = await _user.GetAsync("/Home/Index");
            responce.EnsureSuccessStatusCode();
            var responseString = await responce.Content.ReadAsStringAsync();
            Assert.Contains("Lorem ipsum dolor", responseString);
        }
    }
}