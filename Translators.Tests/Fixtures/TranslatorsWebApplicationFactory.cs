using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Translators.Host;

namespace Translators.Tests.Fixtures;

public class TranslatorsWebApplicationFactory
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureAppConfiguration((context, config) =>
        {
            var testSettings = new Dictionary<string, string?>
            {
                ["Google:ClientId"] = "test-google-client-id",
                ["Jwt:Issuer"] = "TranslatorsTests",
                ["Jwt:Audience"] = "TranslatorsTests",
                ["Jwt:SigningKey"] = "TestSigningKey_MustBeAtLeast32Chars!",
                ["Jwt:ExpirationMinutes"] = "60"
            };

            config.AddInMemoryCollection(testSettings);
        });
    }
}