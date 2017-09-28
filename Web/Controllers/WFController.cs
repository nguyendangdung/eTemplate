using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EF;
using Web.Biz;

namespace Web.Controllers
{
    public class WFController : Controller
    {
		private readonly Context _context = new Context();

        //private SessionHelper _sessionHelper;

        //protected override void Initialize(RequestContext requestContext)
        //{
        //    _sessionHelper = new SessionHelper(requestContext.HttpContext.Session);
        //    base.Initialize(requestContext);
        //}

	    // GET: WF
        public ActionResult Index()
        {
            return View();
        }

		[ChildActionOnly]
	    public ActionResult NavigationHeader(int? wfId)
	    {
		 //   var rootInstructions = _context.Instructions.Where(s => s.ParentInstructionId == null).ToList();
   //         var activeRootInstruction = SessionHelper.SessionControlContainer.Instructions.FirstOrDefault();
   //         ViewBag.ActiveRootInstruction = activeRootInstruction == null ? (int?)null : activeRootInstruction.InstructionId;
			//return PartialView(rootInstructions);

			var rootInstructions = _context.Instructions.Where(s => s.ParentInstructionId == null).ToList();

			if (SessionHelper.SessionControlContainer != null && SessionHelper.SessionControlContainer.Instructions != null)
			{
				var activeRootInstruction = SessionHelper.SessionControlContainer.Instructions.FirstOrDefault();
				ViewBag.ActiveRootInstruction = activeRootInstruction == null ? (int?)null : activeRootInstruction.InstructionId;
			}
			return PartialView(rootInstructions);
		}


	    protected override void Dispose(bool disposing)
	    {
	        if (_context != null)
	        {
	            _context.Dispose();
	        }
		    base.Dispose(disposing);
	    }
    }
}
