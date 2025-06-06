using Duende.IdentityModel;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System.Security.Claims;

namespace IdentityServer.Configuration
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CustomMiddleWare.write")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("CustomMiddleWare")
                {
                    Scopes = new List<string> { "CustomMiddleWare.write" },
                    ApiSecrets = new List<Secret>{new Secret("supersecret".Sha256()) }
                }
            };

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

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
    }
}
