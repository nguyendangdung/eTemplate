using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTemplate.Areas.Admin.Models.Screens;
using eTemplate.Areas.Admin.Models.WorkFolws;
using eTemplate.Bizs;
using eTemplate.SharedComponents.Params.AdminWorkFlows;

namespace eTemplate.Areas.Admin.Controllers
{
    public class WorkFlowsController : Controller
    {
        // GET: Admin/WorkFlows
		/// <summary>
		/// Show a list of workfolws include screens
		/// </summary>
		/// <returns></returns>
        public ActionResult Index()
		{
			var param = new GetWorkFlowsParam();
			MainController.Provider.Execute(param);
			var vm = param.WorkFlowScreenInfos
				.GroupBy(s => new {s.WorkFlowId, s.Name, s.Description},
					(workFlow, screens) => new WorkFlowListItem()
					{
						WorkFlowId = workFlow.WorkFlowId,
						Name = workFlow.Name,
						Description = workFlow.Description,
						Screens = screens.Select(s => new ScreenListItem()
						{
							Url = s.ScreenUrl,
							Name = s.ScreenName,
							ScreenId = s.ScreenId
						})
					});
            return View(vm);
        }


	    public ActionResult Create()
	    {
	        var param = new OnCreatingWorkFlowParam();
            MainController.Provider.Execute(param);
		    var vm = new WorkFlowCreate()
		    {
			    Screens = param.Screens.Select(s => new ScreenListItem()
			    {
				    Url = s.Url,
					Name = s.Name,
					ScreenId = s.ScreenId.GetValueOrDefault()
			    })
		    };

			return View(vm);
	    }

		[HttpPost]
		[ValidateAntiForgeryToken]
	    public ActionResult Create(WorkFlowCreate vm)
	    {
		    return View();
	    }
	}
}