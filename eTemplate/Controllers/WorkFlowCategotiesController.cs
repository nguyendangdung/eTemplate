using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsoleTest;

namespace eTemplate.Controllers
{
    public class WorkFlowCategotiesController : Controller
    {
		[ChildActionOnly]
		public ActionResult WorkFlowCategoties()
		{
			using (var context = new Context())
			{
				var cate = context.WorkFlowCategories.ToList();
				return PartialView(cate);
			}
		}
	}
}