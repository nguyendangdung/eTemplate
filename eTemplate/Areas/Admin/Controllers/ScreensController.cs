using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using eTemplate.Areas.Admin.Models.Screens;
using eTemplate.Bizs;
using eTemplate.SharedComponents.Entities;
using eTemplate.SharedComponents.Params.AdminScreens;

namespace eTemplate.Areas.Admin.Controllers
{
    public class ScreensController : Controller
    {
        // GET: Admin/FormActionMethodMap
        public ActionResult Index()
        {
	        var param = new GetScreenActionMethodMapperParam();
			MainController.Provider.Execute(param);
			var vm = new ScreenList()
			{
				Screens = param.Screens.Select(s => new ScreenListItem()
				{
					Url = s.Url,
					Name = s.Name,
					ScreenId = s.ScreenId.GetValueOrDefault()
				}),
				ActionMethods = param.ActionMethodInfos.Select(s => new ActionMethod()
				{
					Url = s.Url,
					Name = s.Name,
					Description = s.Description
				})
			};
			return View(vm);
        }

	    public ActionResult Create(string url)
	    {
			var param = new GetNewScreenFromUrlParam()
			{
				Url = url
			};

			MainController.Provider.Execute(param);
			var vm = new ScreenCreate()
			{
				Url = url,
				Name = param.Screen.Name,
				Description = param.Screen.Description,
				Thumbnail = param.ThumbnailUrl
			};
			return View(vm);
	    }

		[HttpPost]
		[ValidateAntiForgeryToken]
	    public ActionResult Create(ScreenCreate vm)
	    {
		    if (!ModelState.IsValid)
		    {
			    return View(vm);
		    }
		    var param = new CreateScreenParam()
		    {
			    Screen = new Screen()
			    {
				    Url = vm.Url,
					Name = vm.Name,
					Description = vm.Description
			    }
		    };
			MainController.Provider.Execute(param);
		    return RedirectToAction("Index");
	    }
    }
}