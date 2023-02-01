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
        public async Task GetPositionsTest ()
        {
            var responce = await _user.GetAsync("/api/menu");
            responce.EnsureSuccessStatusCode();
            var responseStr = await responce.Content.ReadAsStringAsync();
            Assert.Contains("id", responseStr);
        }
    }
}