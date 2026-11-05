using System.Net;
using System.Net.Http.Json;
using Translators.Application.Contracts.Authentication.GoogleLogin;
using Translators.Tests.Fixtures;

namespace Translators.Tests.ApiTests.Authentication.GoogleLogin;

public class GoogleLoginHttpTests:BaseApiTest
{
    public GoogleLoginHttpTests(
        TranslatorsWebApplicationFactory factory)
    :base(factory){}

    [Fact]
    public async Task GoogleLogin_WithInvalidToken_ReturnsUnauthorized()
    {
        // Arrange
        var request = new GoogleLoginRequestContract
        {
            IdToken = "invalid-google-token"
        };
        
        // Act
        var response = await Client.PostAsJsonAsync(
            "/api/users/google-login",
            request);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}