using Translators.Tests.Fixtures;

namespace Translators.Tests.ApiTests;

public abstract class BaseApiTest
    : IClassFixture<TranslatorsWebApplicationFactory>
{
    protected readonly HttpClient Client;

    protected BaseApiTest(
        TranslatorsWebApplicationFactory factory)
    {
        Client = factory.CreateClient();
    }
}