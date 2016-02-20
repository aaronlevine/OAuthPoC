using System.Web.Http;
using Microsoft.Owin;
using OAuthPoC;
using Owin;


[assembly: OwinStartup(typeof(AngularJSAuthentication.API.Startup))]
// ReSharper disable once CheckNamespace
namespace AngularJSAuthentication.API
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();
			WebApiConfig.Register(config);
			app.UseWebApi(config);
		}
	}
}