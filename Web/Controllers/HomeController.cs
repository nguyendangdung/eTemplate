using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF;

namespace Web.Controllers
{
	public class HomeController : Controller
	{
	    readonly Context _context = new Context();
		public ActionResult Index()
		{
			//throw new Exception();
			var defaultInstruction = _context.Instructions.FirstOrDefault(s => s.IsDefault);
			if (defaultInstruction == null)
			{
				throw new Exception();
			}
		    return RedirectToAction("Details", "Instructions", new {id = defaultInstruction.InstructionId});
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