using Duende.IdentityModel;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System.Security.Claims;

namespace IdentityServer.Configuration
{

    // In identity server 6 no need to add APIResources(not mandatory)
    public class Config
    {
        // 	Define what actions/permissions a client can request on an API
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CustomMiddleWare.write")
            };

        //	Define which APIs are protected and what scopes apply to them
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("CustomMiddleWare")
                {
                    Scopes = new List<string> { "CustomMiddleWare.write" },
                    ApiSecrets = new List<Secret>{new Secret("supersecret".Sha256()) }
                }
            };

        // Define who can ask for tokens, which grant types and scopes they're allowed
        public static IEnumerable<Client> Clients =>
            new Client[] {
                new Client
                {
                    ClientId = "mvc",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = new [] { new Secret("secret".Sha512()) },
                    AllowedScopes = { "CustomMiddleWare.write", "offline_access" },
                    IdentityTokenLifetime = 50,
                    AccessTokenLifetime = 300, // 120 minute
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AbsoluteRefreshTokenLifetime = 600,
                    SlidingRefreshTokenLifetime = 300,
                }
            };

        // IdentityResources are directly related to what user information appears in the id_token (and optionally via the UserInfo endpoint). 
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
    }
}
