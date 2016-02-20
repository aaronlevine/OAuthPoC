using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace OAuthPoC.Controllers
{
	[RoutePrefix("api/Account")]
	public class AccountController : ApiController
	{
		private AuthRepository _authRepository = null;

		public AccountController()
		{
			_authRepository = new AuthRepository();
		}

		[AllowAnonymous]
		[Route("Register")]
		public async Task<IHttpActionResult> Register(UserModel userModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await _authRepository.RegisterUser(userModel);

			var errorResult = GetErrorResult(result);

			if (errorResult != null)
			{
				return errorResult;
			}

			return Ok();
		}

		private IHttpActionResult GetErrorResult(IdentityResult result)
		{
			if (result == null)
			{
				return InternalServerError();
			}

			if (!result.Succeeded)
			{
				if (result.Errors != null)
				{
					foreach (string error in result.Errors)
					{
						ModelState.AddModelError("", error);
					}
				}

				if (ModelState.IsValid)
				{
					//no modelstate error are available to send, so just return an empty badrequest
					return BadRequest();
				}

				return BadRequest(ModelState);
			}
			return null;
		}
	}
}