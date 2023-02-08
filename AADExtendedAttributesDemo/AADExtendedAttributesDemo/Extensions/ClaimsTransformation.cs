using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AADExtendedAttributesDemo.Extensions
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // ** duplicate block as required
            // transfer the Role claim / pull in additional data to target claim
            var sourceClaimType = "extn.Role";
            var targetClaimType = ClaimTypes.Role;
            // ensure source claim exists
            if (principal.HasClaim(claim => claim.Type == sourceClaimType))
            {
                // validate and transform / add claim
                ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                if (!principal.HasClaim(claim => claim.Type == targetClaimType))
                {
                    claimsIdentity.AddClaim(new Claim(targetClaimType, principal.FindFirstValue(sourceClaimType)));
                }
                // finally add claims and return.
                principal.AddIdentity(claimsIdentity);
            }
            // ** end block
            // final return
            return Task.FromResult(principal);
        }
    }
}
