namespace AirportDistanceCalculator.IntegrationTests
{
    public abstract class TestBase
    {
        protected TestWebApplicationFactory _factory;
        protected HttpClient _client;
        protected string baseUrl = "https://localhost:7099/api/AirportDistanceCalculator";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _factory = new TestWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}
