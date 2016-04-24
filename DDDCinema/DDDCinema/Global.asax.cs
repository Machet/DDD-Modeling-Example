﻿using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DDDCinema.CompositionRoot;
using DDDCinema.DataAccess.DbSetup;

namespace DDDCinema
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			DIConfig.Setup();
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
		}
	}
}
