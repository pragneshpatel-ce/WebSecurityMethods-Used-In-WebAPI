//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebMatrix.WebData;
using WebAPIwithMembership.Models;


namespace WebAPIwithMembership.Filter
{
	public class InitializeSimpleMemberShip : AuthorizeAttribute
	{
		private static SimpleMembershipInitializer _initializer;
		private static object _initializerLock = new object();
		private static bool _isInitialized;

		public override void OnAuthorization(HttpActionContext actionContext)
		{
			LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
		}

		public class SimpleMembershipInitializer
		{
			public SimpleMembershipInitializer()
			{
				Database.SetInitializer<Context>(null);

				try
				{
					using (var context = new Context())
					{
						if (!context.Database.Exists())
						{
							// Create the SimpleMembership database without Entity Framework migration schema
							((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
						}
					}

					WebSecurity.InitializeDatabaseConnection("testcon", "UserProfile", "UserId", "UserName", autoCreateTables: true);
				}
				catch (Exception ex)
				{
					throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
				}
			}
		}
	}
}