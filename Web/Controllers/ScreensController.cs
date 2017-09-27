using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using EF;
using Newtonsoft.Json;
using Web.Biz;
using Web.Models.Instructions;
using Web.Models.Screens;

namespace Web.Controllers
{
    public class ScreensController : Controller
    {
	    readonly Context _context = new Context();
        //private SessionHelper _sessionHelper;
	    readonly CustomerSerivce _customerSerivce = new CustomerSerivce();

        //protected override void Initialize(RequestContext requestContext)
        //{
        //    _sessionHelper = new SessionHelper(requestContext.HttpContext.Session);
        //    base.Initialize(requestContext);
        //}

	    // GET: Forms
        public ActionResult CustomerInfo(InputParams param)
        {
	        using (var context = new Context())
	        {
                var sessionId = SessionHelper.SessionId;

		        var sessionData = context.SessionDetails
			        .Include(s => s.Instruction.Screen)
			        .FirstOrDefault(s => s.SessionId == sessionId && s.InstructionId == param.Instruction.InstructionId);
		        var instruction = context.Instructions.Find(param.Instruction.InstructionId);
		        if (instruction == null)
		        {
			        throw new Exception();
		        }
		        CustomerInfoData data = null;
				var modelFromParent = ControllerContext.ParentActionViewContext.ViewBag.Model as CustomerInfoVM;
		        if (sessionData == null)
		        {
			        data = modelFromParent == null ? null : modelFromParent.Data;
		        }
		        else
		        {
			        data = string.IsNullOrWhiteSpace(sessionData.Data)
				        ? null
				        : sessionData.Data.XmlDeserializeFromString<CustomerInfoData>();

		        }

				return PartialView(new CustomerInfoVM()
		        {
					Instruction = instruction,
			        Data = data
				});
	        }
            
        }

		[HttpPost]
	    public ActionResult CustomerInfo(CustomerInfoVM vm)
		{
			if (!ModelState.IsValid)
		    {
			    return PartialView(vm);
		    }
            var sessionId = SessionHelper.SessionId;
			var session = _context.Sessions.Find(sessionId);
			if (session == null)
			{
				throw new Exception();
			}
			var customer = _customerSerivce.Get(vm.Data.CustomerName, vm.Data.AccountNumber);
			if (customer == null && vm.NavigationButton == NavigationButton.Next)
			{
				ModelState.AddModelError("", "Sai thông tin tài khoản, vui lòng nhập lại thông tin");
				TempData["ViewData"] = ViewData;
				ViewData.Model = vm;

				var dic = vm.GetKeyValuePair();
				dic.ForEach(s =>
				{
					HttpContext.Session[s.Key] = s.Value;
				});

				return RedirectToAction("Details", "Instructions",
					new {id = vm.Instruction.InstructionId});
			}

			return ActionResult(vm);
		}

	    public ActionResult CustomerInfoReview(InputParams param)
	    {
		    using (var context = new Context())
		    {
                //var sessionId = _sessionHelper.SessionId;
                //var sessionData = context.SessionDetails
                //    .Include(s => s.Instruction.Screen)
                //    .FirstOrDefault(s => s.SessionId == sessionId && s.InstructionId == param.Instruction.InstructionId);
			    var instruction = context.Instructions.Find(param.Instruction.InstructionId);
			    if (instruction == null)
			    {
				    throw new Exception();
			    }
		        return PartialView(new CustomerInfoReviewVM()
		        {
		            //SessionId = sessionId,
		            Instruction = instruction,
		            Data = new CustomerInfoReviewData()
		            {
		                CustomerName = (string)HttpContext.Session["CustomerName"],
		                AccountNumber = (string)HttpContext.Session["AccountNumber"],
		                Balance = 123,
		                CustomerType = CustomerType.Vip,
		                Id = 1
		            }
		        });
		    }
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
	    public ActionResult CustomerInfoReview(CustomerInfoReviewVM vm)
	    {
		    return MenuActionResult(vm);
	    }

		public ActionResult MoneyDetails(InputParams param)
	    {
			using (var context = new Context())
			{
                var sessionId = SessionHelper.SessionId;
				// Search SessionDetails by SessionId and InstructionId
				var sessionData = context.SessionDetails
					.Include(s => s.Instruction.Screen)
					.FirstOrDefault(s => s.SessionId == sessionId && s.InstructionId == param.Instruction.InstructionId);
				var instruction = context.Instructions.Find(param.Instruction.InstructionId);
				if (instruction == null)
				{
					throw new Exception();
				}
				//if (param.IsReporter)
				//{
				//	var aa = sessionData == null
				//		? null
				//		: string.IsNullOrWhiteSpace(sessionData.Data)
				//			? null
				//			: sessionData.Data.XmlDeserializeFromString<MoneyDetailsData>();
				//	return PartialView("MoneyDetailsReporter", aa);
				//}

			    MoneyDetailsData data;
			    if (sessionData == null || string.IsNullOrWhiteSpace(sessionData.Data) ||
			        sessionData.Data.XmlDeserializeFromString<MoneyDetailsData>() == null)
			    {
			        data = new MoneyDetailsData() { Denominations = Denomination.Denominations() };
			    }
			    else
			    {
			        data = sessionData.Data.XmlDeserializeFromString<MoneyDetailsData>();
			    }

			    var vm = new MoneyDetailsVM()
				{
					Instruction = instruction,
					Data = data
				};
				return PartialView(vm);
			}
		}


	    [HttpPost]
		public ActionResult MoneyDetails(MoneyDetailsVM vm)
	    {
			if (!ModelState.IsValid)
		    {
			    return PartialView(vm);
		    }

		    return ActionResult(vm);
		}

	    private ActionResult MenuActionResult(ScreenVM vm)
	    {
            var sessionId = SessionHelper.SessionId;
		    var session = sessionId == null ? null : _context.Sessions.Find(sessionId);
		    if (session == null)
		    {
			    throw new Exception();
		    }
			switch (vm.NavigationButton)
			{
				case NavigationButton.Back:
					return RedirectToAction("Details", "Instructions",
						new { id = vm.Instruction.PreviousInstructionId });
				case NavigationButton.Next:
					if (vm.Instruction.NextInstructionId == null)
					{
						return RedirectToAction("PreviewAndPrint", "Sessions",
							new { id = session.SessionId, previousInstructionId = vm.Instruction.InstructionId });
					}
					else
					{
						return RedirectToAction("Details", "Instructions",
							new { id = vm.Instruction.NextInstructionId });
					}
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private ActionResult ActionResult(ScreenVM vm)
		{
            var sessionId = SessionHelper.SessionId;
			var session = sessionId == null ? null : _context.Sessions.Find(sessionId);
			if (session == null)
			{
				throw new Exception();
			}
		    var sessionData = _context.SessionDetails
			    .Include(s => s.Instruction.Screen)
			    .FirstOrDefault(s => s.SessionId == session.SessionId && s.InstructionId == vm.Instruction.InstructionId);

		    if (sessionData == null)
		    {
			    sessionData = new SessionDetail()
			    {
				    SessionId = session.SessionId,
				    InstructionId = vm.Instruction.InstructionId,
				    Data = vm.GetData()
			    };
			    _context.SessionDetails.Add(sessionData);
		    }
		    else
		    {
			    sessionData.Data = vm.GetData();
		    }
			_context.SaveChanges();
		    var dic = vm.GetKeyValuePair();
			dic.ForEach(s =>
			{
			    SessionHelper.Data[s.Key] = s.Value;
				HttpContext.Session[s.Key] = s.Value;
			});


			switch (vm.NavigationButton)
		    {
			    case NavigationButton.Back:
					return RedirectToAction("Details", "Instructions",
					    new {id = vm.Instruction.PreviousInstructionId});
			    case NavigationButton.Next:
				    if (vm.Instruction.NextInstructionId == null)
				    {
					    return RedirectToAction("PreviewAndPrint", "Sessions",
						    new {id = session.SessionId, previousInstructionId = vm.Instruction.InstructionId});
				    }
				    else
				    {
					    return RedirectToAction("Details", "Instructions",
						    new {id = vm.Instruction.NextInstructionId });
				    }
			    default:
				    throw new ArgumentOutOfRangeException();
		    }
	    }

	 //   public ActionResult Index2(InputParams param)
	 //   {
		//    using (var context = new Context())
		//    {
		//	    // Search SessionDetails by SessionId and InstructionId
		//	    var sessionData = context.SessionDetails
		//		    .Include(s => s.Instruction.Screen)
		//		    .FirstOrDefault(s => s.SessionId == param.SessionId && s.InstructionId == param.Instruction.InstructionId
		//								&& s.SessionId == param.SessionId);
		//	    var instruction = context.Instructions.Find(param.Instruction.InstructionId);
		//	    if (instruction == null)
		//	    {
		//		    throw new Exception();
		//	    }

		//	    if (param.IsReporter)
		//	    {
		//		    return PartialView("Index2Reporter", sessionData == null
		//			    ? null
		//			    : string.IsNullOrWhiteSpace(sessionData.Data)
		//				    ? null
		//				    : sessionData.Data.XmlDeserializeFromString<Index2Data>());
		//	    }
		//	    return PartialView(new Index2VM()
		//	    {
		//		    SessionId = param.SessionId,
		//			Instruction = instruction,
		//		    //TheNextInstructionId = instruction.NextInstructionId,
		//		    //ThePreviousInstructionId = instruction.PreviousInstructionId,
		//		    //TheCurrentInstructionId = instruction.InstructionId,
		//		    Data = sessionData == null ? null : string.IsNullOrWhiteSpace(sessionData.Data)
		//			    ? null
		//				: sessionData.Data.XmlDeserializeFromString<Index2Data>()
		//		});
		//    }

		//}

	 //   [HttpPost]
	 //   [ValidateAntiForgeryToken]
	 //   public ActionResult Index2(Index2VM vm)
	 //   {
		//	if (!ModelState.IsValid)
		//    {
		//	    return PartialView(vm);
		//    }

		//    return ActionResult(vm);
		//}

		//public ActionResult Index3(InputParams param)
	 //   {
		//    using (var context = new Context())
		//    {
		//	    var sessionId = (int)HttpContext.Session["SessionId"];

		//	    var sessionData = context.SessionDetails
		//		    .Include(s => s.Instruction.Screen)
		//		    .FirstOrDefault(s => s.SessionId == sessionId &&
		//								s.InstructionId == param.Instruction.InstructionId);

		//	    if (sessionData == null)
		//	    {
		//		    return RedirectToAction("Index", "Home");
		//	    }
		//	    var instruction = sessionData.Instruction;

		//		return PartialView(new Index3VM()
		//	    {
		//		    SessionId = sessionId,
		//		    Instruction = instruction,
		//			//TheNextInstructionId = instruction.NextInstructionId,
		//			//ThePreviousInstructionId = instruction.PreviousInstructionId,
		//			//TheCurrentInstructionId = instruction.InstructionId,
		//			Data = string.IsNullOrWhiteSpace(sessionData.Data)
		//			    ? null
		//			    : sessionData.Data.XmlDeserializeFromString<Index3Data>()
		//		});
		//    }
	 //   }

	 //   [HttpPost]
	 //   [ValidateAntiForgeryToken]
	 //   public ActionResult Index3(Index3VM vm)
	 //   {
		//	if (!ModelState.IsValid)
		//	{
		//		return PartialView(vm);
		//	}
		//    return ActionResult(vm);
		//}

		//public ActionResult Index4(InputParams param)
	 //   {
		//    using (var context = new Context())
		//    {
		//	    var sessionData = context.SessionDetails
		//		    .Include(s => s.Instruction.Screen)
		//		    .FirstOrDefault(s => s.SessionId == param.SessionId && s.InstructionId == param.Instruction.InstructionId
		//								&& s.SessionId == param.SessionId);

		//	    if (sessionData == null)
		//	    {
		//		    return RedirectToAction("Index", "Home");
		//	    }
		//	    var instruction = sessionData.Instruction;

		//		return PartialView(new Index4VM()
		//	    {
		//		    SessionId = param.SessionId,
		//		    Instruction = instruction,
		//			//TheNextInstructionId = instruction.NextInstructionId,
		//			//ThePreviousInstructionId = instruction.PreviousInstructionId,
		//			//TheCurrentInstructionId = instruction.InstructionId,
		//			Data = string.IsNullOrWhiteSpace(sessionData.Data)
		//			    ? null
		//			    : sessionData.Data.XmlDeserializeFromString<Index4Data>()
		//		});
		//    }
	 //   }

	 //   [HttpPost]
	 //   [ValidateAntiForgeryToken]
	 //   public ActionResult Index4(Index4VM vm)
	 //   {
		//	if (!ModelState.IsValid)
		//	{
		//		return PartialView(vm);
		//	}
		//    return ActionResult(vm);
		//}


	    public ActionResult BussinessLend(InputParams param)
	    {
		    using (var context = new Context())
		    {
                var sessionId = SessionHelper.SessionId;
				var sessionData = context.SessionDetails
				    .Include(s => s.Instruction.Screen)
				    .FirstOrDefault(s => s.SessionId == sessionId && s.InstructionId == param.Instruction.InstructionId);
			    var instruction = context.Instructions.Find(param.Instruction.InstructionId);
			    if (instruction == null)
			    {
				    throw new Exception();
			    }
			    //if (param.IsReporter)
			    //{
				   // return PartialView("BussinessLendReporter", sessionData == null
					  //  ? null
					  //  : string.IsNullOrWhiteSpace(sessionData.Data)
						 //   ? null
						 //   : sessionData.Data.XmlDeserializeFromString<BussinessLendData>());
			    //}
			    return PartialView(new BussinessLendVM()
			    {
				    //SessionId = sessionId,
				    Instruction = instruction,
				    Data = sessionData == null ? null : string.IsNullOrWhiteSpace(sessionData.Data)
					    ? null
					    : sessionData.Data.XmlDeserializeFromString<BussinessLendData>()
			    });
		    }
		}

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public ActionResult BussinessLend(BussinessLendVM vm)
	    {
		    if (!ModelState.IsValid)
		    {
			    return PartialView(vm);
		    }
		    return ActionResult(vm);
	    }

		[ChildActionOnly]
	    public ActionResult Navi1(InputParams param)
		{
            var sessionId = SessionHelper.SessionId;
			var session = _context.Sessions.FirstOrDefault(s => s.SessionId == sessionId && s.Status == Status.Active);
			if (session == null)
			{
				throw new Exception();
			}
			var instruction = _context.Instructions.Include(s => s.SubInstructions)
				.FirstOrDefault(s => s.InstructionId == param.Instruction.InstructionId);
			if (instruction == null)
			{
				throw new Exception();
			}
			var subInstructions = instruction.SubInstructions.ToList();
			var iconIds = subInstructions.Select(s => s.IconID).ToList();
			var icons = _context.AdmSystemParameters.Select(s => new {s.SystemParameterId, s.Ext1})
				.Where(s => iconIds.Contains(s.SystemParameterId)).ToList();
			icons = icons.Select(s => new {s.SystemParameterId, Ext1 = "http://localhost:3934/" + Server.GetUrl(s.Ext1)})
				.ToList();

			var vm = new NaviDetailsVM()
			{
				Instruction = instruction,
				Data = new NaviDetailsData()
				{
					Instructions = subInstructions.Select(s =>
					{
						var icon = icons.FirstOrDefault(t => t.SystemParameterId == s.IconID);
						return new InstructionListItem()
						{
							Name = s.Name,
							InstructionId = s.InstructionId,
							IconUrl = icon == null ? "" : icon.Ext1
						};
					}).ToList()
				}
			};

		    return PartialView(vm);
	    }

	    [HttpPost]
		[ValidateAntiForgeryToken]
	    public ActionResult Navi1(NaviDetailsVM vm)
	    {
		    return MenuActionResult(vm);
	    }
	}
}