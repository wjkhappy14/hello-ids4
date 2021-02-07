using IdentityServer4.EntityFramework.Entities;

namespace Skoruba.IdentityServer4.Admin.EntityFramework
{
    public class IdentityClaim : UserClaim
    {
        public IdentityClaim() { }

        public int IdentityResourceId { get; set; }
        public IdentityResource IdentityResource { get; set; }
    }
}
