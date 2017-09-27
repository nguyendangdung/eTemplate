using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsoleTest;

namespace eTemplate.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			// return View();
			return RedirectToAction("workflowcategorydetails", new {id = 1});
		}

	    public ActionResult WorkFlowCategoryDetails(int id)
	    {
	        using (var context = new Context())
	        {
	            var cate = context.WorkFlowCategories.Include(s => s.WorkFlows)
	                .FirstOrDefault(s => s.WorkFlowCategoryId == id);
	            if (cate == null)
	            {
	                return HttpNotFound();
	            }

	            return View(cate);
	        }
	    }

        [HttpPost]
	    public ActionResult CreateSession(int id)
	    {
	        using (var context = new Context())
	        {
	            // Get personal workflow
	            var workFlow = context.WorkFlows.FirstOrDefault(s => s.WorkFlowId == id);
	            if (workFlow == null)
	            {
	                throw new Exception();
	            }

	            // Search unfinish session
	            var unFinishedSessions = context.Sessions.Where(s => s.WorkFlowId == workFlow.WorkFlowId && !s.Finished).ToList();
	            if (unFinishedSessions.Any())
	            {
	                // Finish all unfinish sessions
	                unFinishedSessions.ForEach(s => s.Finished = true);
	            }

	            // Create new Session and All SessionData holder
	            var session = new Session()
	            {
	                WorkFlowId = workFlow.WorkFlowId,
	                StartDTG = DateTime.Now,
	                Status = Status.Active,
	                SessionDatas = workFlow.WorkFlowScreens.Select(s => new SessionData()
	                {
	                    ScreenId = s.ScreenId,
	                    Order = s.Order
	                }).ToList()
	            };

	            context.Sessions.Add(session);
	            context.SaveChanges();

	            // Go to the Session details
	            return RedirectToAction("Details", "Sessions", new { id = session.SessionId });
	        }
	    }
	}
}