using Microsoft.AspNetCore.Authentication;

namespace HakobuNotifikado.API.Middleware;

public class XApiTokenAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "ApiToken";
    public string Scheme => DefaultScheme;
    public string AuthenticationType = DefaultScheme;
}
