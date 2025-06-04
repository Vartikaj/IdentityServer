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
                {
                    //Scopes = { "CustomMiddleWare.write" },
                    UserClaims = { "userdata" }
                },
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("CustomMiddleWare")
                {
                    Scopes = new List<string> { "CustomMiddleWare.write" },
                    ApiSecrets = new List<Secret>{new Secret("supersecret".Sha256()) },
                    UserClaims = { "userdata" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[] {
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Demo",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "CustomMiddleWare.write" },
                    AccessTokenType = AccessTokenType.Jwt,
                    IdentityTokenLifetime = 50,
                    AccessTokenLifetime = 28800, // 120 minute
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AbsoluteRefreshTokenLifetime = 6000,
                    SlidingRefreshTokenLifetime = 300,
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        //public static List<TestUser> TestUser =>
        //    new List<TestUser>{
        //        new TestUser
        //        {
        //            SubjectId = "1144",
        //            Username = "mukesh",
        //            Password = "mukesh",
        //            Claims =
        //            {
        //                new Claim(JwtClaimTypes.Name, "Mukesh Murugan"),
        //                new Claim(JwtClaimTypes.GivenName, "Mukesh"),
        //                new Claim(JwtClaimTypes.FamilyName, "Murugan"),
        //                new Claim(JwtClaimTypes.WebSite, "http://codewithmukesh.com"),
        //            }
        //        }
        //    };
    }
}
