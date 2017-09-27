using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using eTemplate.Bizs;
using eTemplate.Bizs.Services;
using eTemplate.Services;
using eTemplate.SharedComponents;

namespace eTemplate
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static IContainer Container;
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);


			AutofacConfig.Builder.RegisterType<ActionMethodService>().As<IActionMethodService>();
			AutofacConfig.Builder.RegisterType<HardCodeSystemConfigSerivce>().As<ISystemConfigSerivce>().SingleInstance();
			AutofacConfig.Builder.RegisterType<WebHelperService>().As<IWebHelperService>();
			AutofacConfig.Builder.RegisterType<ThumbnailHelperService>().As<IThumbnailHelperService>();
			
			AutofacConfig.RegisterAutofac();
		}
	}
}
