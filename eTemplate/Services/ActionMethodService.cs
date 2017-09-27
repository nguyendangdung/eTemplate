using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using eTemplate.Bizs.Services;
using eTemplate.Controllers;
using eTemplate.SharedComponents.EntityInfos;

namespace eTemplate.Services
{
	public class ActionMethodService : IActionMethodService
	{
		public IEnumerable<ActionMethodInfo> GetActionMethodInfos()
		{
			var asm = Assembly.GetExecutingAssembly();
			var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
			return asm.GetTypes()
				.Where(type => typeof(ScreensController).IsAssignableFrom(type)) //filter controllers
				.SelectMany(type => type.GetMethods())
				.Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
				.Where(s => s.ReturnType == typeof(ActionResult))
				.Select(s => new ActionMethodInfo
				{
					Url = urlHelper.Action(s.Name, "Screens", new {area = ""}),
					Name = s.Name
				});
		}
	}
}