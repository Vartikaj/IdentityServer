using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using System.Security.Claims;

namespace IdentityServer
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                context.Result = new GrantValidationResult(context.UserName, GrantType.ResourceOwnerPassword, GetUserClaims(context.Request.Raw.Get("userdata")));
                
            } catch(Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }

            return Task.CompletedTask;
        }

        public static List<Claim> GetUserClaims(string userdata)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(""));
        }
    }
}
