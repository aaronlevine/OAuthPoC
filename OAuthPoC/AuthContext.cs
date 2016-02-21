using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuthPoC
{
    public class AuthContext : IdentityDbContext<IdentityUser>
	{
		public AuthContext() : base("AuthContext")
		{
		}
	}
}