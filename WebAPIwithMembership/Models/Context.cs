﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPIwithMembership.Models
{
	public class Context : DbContext
	{
		public Context() : base("testcon") { }
	}
}