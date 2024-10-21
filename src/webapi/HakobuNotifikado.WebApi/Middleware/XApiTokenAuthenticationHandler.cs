using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace HakobuNotifikado.WebApi.Middleware;

public class XApiTokenAuthenticationHandler(
    IOptionsMonitor<XApiTokenAuthenticationOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    ISystemClock clock)
    : AuthenticationHandler<XApiTokenAuthenticationOptions>(options, logger, encoder, clock)
{
    private const string _xApiTokenHeaderName = "X-API-TOKEN";
    private readonly string _validToken = "hello-hakobu";

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(_xApiTokenHeaderName, out var tokenValues))
        {
            return Task.FromResult(AuthenticateResult.Fail("API token is missing."));
        }

        var firstTokenValue = tokenValues.FirstOrDefault();
        if (firstTokenValue != _validToken)
        {
            return Task.FromResult(AuthenticateResult.Fail("API token is invalid."));
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "XApiUser"),
            new Claim(ClaimTypes.Name, "XApiUser")
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}