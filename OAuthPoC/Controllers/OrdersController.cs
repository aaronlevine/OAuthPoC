using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAuthPoC.Models;

namespace OAuthPoC.Controllers
{
	public class OrdersController : ApiController
	{
		[Authorize]
		public IHttpActionResult Get()
		{
			return Ok(Order.CreateOrders());
		}
	}
}
