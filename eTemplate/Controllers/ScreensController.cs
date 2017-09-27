using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsoleTest;
using eTemplate.Models.Screens;
using Newtonsoft.Json;

namespace eTemplate.Controllers
{
    public class ScreensController : Controller
    {
        // GET: Forms
        public ActionResult Index(InputParams param)
        {
	        using (var context = new Context())
	        {
		        var sessionData = context.SessionDatas
			        .FirstOrDefault(s => s.ScreenId == param.TheCurrentScreenId 
					&& s.SessionId == param.SessionId);
		        if (sessionData == null)
		        {
		            return RedirectToAction("Index", "Home");
		        }
		        return PartialView(new IndexVM()
		        {
			        SessionId = param.SessionId,
			        TheNextScreenId = param.TheNextScreenId,
			        ThePreviousScreenId = param.ThePreviousScreenId,
			        TheCurrentScreenId = param.TheCurrentScreenId,
			        Data = string.IsNullOrWhiteSpace(sessionData.Data)
				        ? null
				        : JsonConvert.DeserializeObject<IndexData>(sessionData.Data)
		        });
	        }
            
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
	    public ActionResult Index(IndexVM vm)
	    {
		    if (!ModelState.IsValid)
		    {
				return PartialView(vm);
			}

			// Save
			using (var context = new Context())
			{
				var sessionData = context.SessionDatas
					.FirstOrDefault(s => s.ScreenId == vm.TheCurrentScreenId
										&& s.SessionId == vm.SessionId);
				if (sessionData == null)
				{
				    return RedirectToAction("Index", "Home");
				}

				sessionData.Data = JsonConvert.SerializeObject(vm.Data);
				if (vm.TheNextScreenId == null && vm.NavigationButton == NavigationButton.Next)
				{
					var session = context.Sessions.Find(vm.SessionId);
					if (session != null)
					{
						session.Finished = true;
					}
				}
				context.SaveChanges();
			}

			switch (vm.NavigationButton)
			{
				case NavigationButton.Back:
					return RedirectToAction("Details", "Sessions", new { id = vm.SessionId, screenId = vm.ThePreviousScreenId });
				case NavigationButton.Next:
					if (vm.TheNextScreenId == null)
					{
						return RedirectToAction("PreviewAndPrint", "Sessions", new {id = vm.SessionId});
					}
					else
					{
						return RedirectToAction("Details", "Sessions", new { id = vm.SessionId, screenId = vm.TheNextScreenId });
					}
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public ActionResult Index2(InputParams param)
	    {
			using (var context = new Context())
			{
				var sessionData = context.SessionDatas
					.FirstOrDefault(s => s.ScreenId == param.TheCurrentScreenId
										&& s.SessionId == param.SessionId);
				if (sessionData == null)
				{
				    return RedirectToAction("Index", "Home");
				}
				return PartialView(new Index2VM()
				{
					SessionId = param.SessionId,
					TheNextScreenId = param.TheNextScreenId,
					ThePreviousScreenId = param.ThePreviousScreenId,
					TheCurrentScreenId = param.TheCurrentScreenId,
					Data = string.IsNullOrWhiteSpace(sessionData.Data)
						? null
						: JsonConvert.DeserializeObject<Index2Data>(sessionData.Data)
				});
			}
		    
		}

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public ActionResult Index2(Index2VM vm)
	    {
		    if (!ModelState.IsValid)
		    {
			    return PartialView(vm);
		    }
		    using (var context = new Context())
		    {
				var sessionData = context.SessionDatas
					.FirstOrDefault(s => s.ScreenId == vm.TheCurrentScreenId
										&& s.SessionId == vm.SessionId);
				if (sessionData == null)
			    {
			        return RedirectToAction("Index", "Home");
			    }

			    sessionData.Data = JsonConvert.SerializeObject(vm.Data);
				if (vm.TheNextScreenId == null && vm.NavigationButton == NavigationButton.Next)
				{
				    var session = context.Sessions.Find(vm.SessionId);
				    if (session != null)
				    {
					    session.Finished = true;
				    }
			    }
				context.SaveChanges();
		    }
			switch (vm.NavigationButton)
		    {
			    case NavigationButton.Back:
				    return RedirectToAction("Details", "Sessions", new { id = vm.SessionId, screenId = vm.ThePreviousScreenId });
			    case NavigationButton.Next:
					if (vm.TheNextScreenId == null)
					{
						return RedirectToAction("PreviewAndPrint", "Sessions", new {id = vm.SessionId});
					}
					else
					{
						return RedirectToAction("Details", "Sessions", new { id = vm.SessionId, screenId = vm.TheNextScreenId });
					}
				default:
				    throw new ArgumentOutOfRangeException();
		    }
	    }

		public ActionResult Index3(InputParams param)
	    {
		    using (var context = new Context())
		    {
				var sessionData = context.SessionDatas
					.FirstOrDefault(s => s.ScreenId == param.TheCurrentScreenId
										&& s.SessionId == param.SessionId);
				if (sessionData == null)
			    {
			        return RedirectToAction("Index", "Home");
			    }

			    return PartialView(new Index3VM()
			    {
				    SessionId = param.SessionId,
				    TheNextScreenId = param.TheNextScreenId,
				    ThePreviousScreenId = param.ThePreviousScreenId,
				    TheCurrentScreenId = param.TheCurrentScreenId,
				    Data = string.IsNullOrWhiteSpace(sessionData.Data)
					    ? null
					    : JsonConvert.DeserializeObject<Index3Data>(sessionData.Data)
				});
		    }
	    }

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public ActionResult Index3(Index3VM vm)
	    {
		    if (!ModelState.IsValid)
		    {
			    return PartialView(vm);
		    }
		    using (var context = new Context())
		    {
				var sessionData = context.SessionDatas
					.FirstOrDefault(s => s.ScreenId == vm.TheCurrentScreenId
										&& s.SessionId == vm.SessionId);
				if (sessionData == null)
			    {
			        return RedirectToAction("Index", "Home");
			    }

			    sessionData.Data = JsonConvert.SerializeObject(vm.Data);
				if (vm.TheNextScreenId == null && vm.NavigationButton == NavigationButton.Next)
				{
				    var session = context.Sessions.Find(vm.SessionId);
				    if (session != null)
				    {
					    session.Finished = true;
				    }
			    }
				context.SaveChanges();
		    }
			switch (vm.NavigationButton)
		    {
			    case NavigationButton.Back:
				    return RedirectToAction("Details", "Sessions", new { id = vm.SessionId, screenId = vm.ThePreviousScreenId });
			    case NavigationButton.Next:
				    if (vm.TheNextScreenId == null)
				    {
					    return RedirectToAction("PreviewAndPrint", "Sessions", new {id = vm.SessionId});
				    }
					else
					{
						return RedirectToAction("Details", "Sessions", new { id = vm.SessionId, screenId = vm.TheNextScreenId });
					}
				    
			    default:
				    throw new ArgumentOutOfRangeException();
		    }
	    }

		public ActionResult Index4(InputParams param)
	    {
		    using (var context = new Context())
		    {
				var sessionData = context.SessionDatas
					.FirstOrDefault(s => s.ScreenId == param.TheCurrentScreenId
										&& s.SessionId == param.SessionId);
				if (sessionData == null)
			    {
			        return RedirectToAction("Index", "Home");
			    }

			    return PartialView(new Index4VM()
			    {
				    SessionId = param.SessionId,
				    TheNextScreenId = param.TheNextScreenId,
				    ThePreviousScreenId = param.ThePreviousScreenId,
				    TheCurrentScreenId = param.TheCurrentScreenId,
				    Data = string.IsNullOrWhiteSpace(sessionData.Data)
					    ? null
					    : JsonConvert.DeserializeObject<Index4Data>(sessionData.Data)
				});
		    }
	    }

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public ActionResult Index4(Index4VM vm)
	    {
		    if (!ModelState.IsValid)
		    {
			    return PartialView(vm);
		    }
		    using (var context = new Context())
		    {
				var sessionData = context.SessionDatas
					.FirstOrDefault(s => s.ScreenId == vm.TheCurrentScreenId
										&& s.SessionId == vm.SessionId);
				if (sessionData == null)
			    {
			        return RedirectToAction("Index", "Home");
			    }

			    sessionData.Data = JsonConvert.SerializeObject(vm.Data);
				if (vm.TheNextScreenId == null && vm.NavigationButton == NavigationButton.Next)
				{
				    var session = context.Sessions.Find(vm.SessionId);
				    if (session != null)
				    {
					    session.Finished = true;
				    }
			    }
				context.SaveChanges();
		    }
			switch (vm.NavigationButton)
		    {
			    case NavigationButton.Back:
				    return RedirectToAction("Details", "Sessions", new { id = vm.SessionId, screenId = vm.ThePreviousScreenId });
			    case NavigationButton.Next:
					if (vm.TheNextScreenId == null)
					{
						return RedirectToAction("PreviewAndPrint", "Sessions", new {id = vm.SessionId});
					}
					else
					{
						return RedirectToAction("Details", "Sessions", new { id = vm.SessionId, screenId = vm.TheNextScreenId });
					}
				default:
				    throw new ArgumentOutOfRangeException();
		    }
	    }
	}
}