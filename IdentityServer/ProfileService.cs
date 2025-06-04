using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

namespace IdentityServer
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //>Processing
            //   var user = await _userManager.GetUserAsync(context.Subject);
            context.IssuedClaims.AddRange(context.Subject.Claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            //>Processing
            // var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = true;// (user != null) && user.IsActive;
        }
    }
}
