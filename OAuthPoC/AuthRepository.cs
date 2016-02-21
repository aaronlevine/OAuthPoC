using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuthPoC
{
	public class AuthRepository : IDisposable
	{
		private AuthContext _authContext;

		private UserManager<IdentityUser> _userManager;

		public AuthRepository()
		{
			_authContext = new AuthContext();
			_userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_authContext));
		}

		public async Task<IdentityResult> RegisterUser(UserModel userModel)
		{
			var user = new IdentityUser()
			{
				UserName = userModel.UserName
			};

			var result = await _userManager.CreateAsync(user, userModel.Password);
			return result;
		}

		public async Task<IdentityUser> FindUser(string username, string password)
		{
			var user = await _userManager.FindAsync(username, password);
			return user;
		}

		public void Dispose()
		{
			_authContext.Dispose();
			_userManager.Dispose();
		}
	}
}