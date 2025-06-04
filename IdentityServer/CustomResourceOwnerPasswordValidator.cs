using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using Microsoft.AspNetCore.DataProtection;
using System.Security;
using System.Security.Claims;

namespace IdentityServer
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var userdata = context.Request.Raw.Get("userdata");

                var claims = GetUserClaims(userdata); // returns List<Claim>

                context.Result = new GrantValidationResult(
                    subject: context.UserName,
                    authenticationMethod: GrantType.ResourceOwnerPassword,
                    claims: claims
                );
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "Invalid username or password"
                );
            }

            return Task.CompletedTask;
        }

        public static List<Claim> GetUserClaims(string userdata)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("userdata", userdata));

            return claims;
        }
    }
}
