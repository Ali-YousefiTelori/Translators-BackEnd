using System.Net;
using System.Net.Http.Json;
using Translators.Application.Contracts.Authentication.GoogleLogin;
using Translators.Tests.Fixtures;

namespace Translators.Tests.ApiTests.Authentication.GoogleLogin;

public class GoogleLoginHttpTests
    : IClassFixture<TranslatorsWebApplicationFactory>
{
    private readonly HttpClient _client;

    public GoogleLoginHttpTests(
        TranslatorsWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GoogleLogin_WithInvalidToken_ReturnsUnauthorized()
    {
        // Arrange
        var request = new GoogleLoginRequestContract
        {
            IdToken = "invalid-google-token"
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/users/google-login",
            request);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}