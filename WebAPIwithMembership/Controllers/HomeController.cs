using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebMatrix.WebData;
//using System.Web.Mvc;
using WebAPIwithMembership.Filter;
using System.Web.Security;

namespace WebAPIwithMembership.Controllers
{
	[InitializeSimpleMemberShip]
	public class HomeController : ApiController
	{
		[HttpGet]
        [AllowAnonymous]
		public HttpResponseMessage Index()
		{

			WebSecurity.CreateUserAndAccount("test132", "123456");
			return new HttpResponseMessage()
			{
				StatusCode = HttpStatusCode.OK,
			};
		}

		[HttpGet]
		public HttpResponseMessage changePass()
		{
			WebSecurity.ChangePassword("test132", "123456", "newPass");

			return new HttpResponseMessage()
			{
				StatusCode = HttpStatusCode.OK,
			};
		}
		[HttpGet]
		public HttpResponseMessage generateToken()
		{
			WebSecurity.GeneratePasswordResetToken("test132", 5);
			return new HttpResponseMessage()
			{
				StatusCode = HttpStatusCode.OK,
			};
		}
	}
}
