using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EF;
using Web.Biz;
using Web.Models.Instructions;

namespace Web.Controllers
{
    public class InstructionsController : Controller
    {
        private readonly Context _context = new Context();
        //private SessionHelper _sessionHelper;

        //protected override void Initialize(RequestContext requestContext)
        //{
        //    _sessionHelper = new SessionHelper(requestContext.HttpContext.Session);
        //    base.Initialize(requestContext);
        //}

        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Details(int id)
        {
            var instruction = _context.Instructions.Find(id);
            if (instruction == null)
            {
                return HttpNotFound();
            }

            var session = SessionHelper.SessionId == null
                ? null
                : _context.Sessions.FirstOrDefault(s => s.SessionId == SessionHelper.SessionId &&
                                                        s.Status == Status.Active);
            if (SessionHelper.SessionId != null && session == null)
                throw new Exception("Looix");

            var isMenuInstruction = instruction.NextInstructionId == null && instruction.SubInstructions.Any();
	        var isRootInstruction = instruction.ParentInstructionId == null;
            //var inProgress = session != null && session.SessionDetails.Any();
            if (!isRootInstruction && !isMenuInstruction && (SessionHelper.SessionId == null || session == null))
            {
                return RedirectToAction("index", "home");
            }


            var isNewSession = session == null // 
                || isMenuInstruction;
            if (isNewSession)
            {
                // Because need to create new session => Need deactivate the cureent session as web
                List<InstructionListItem> lstInst = new List<InstructionListItem>();
                if (session != null)
                {
                    session.Status = Status.Inactive;

                    // isMenuInstruction == true
	                if (!isRootInstruction)
	                {
		                var index = SessionHelper.SessionControlContainer.Instructions.FirstOrDefault(s => s.InstructionId == id);
		                if (index != null)
		                {
			                var i = SessionHelper.SessionControlContainer.Instructions.IndexOf(index);
			                lstInst = SessionHelper.SessionControlContainer.Instructions.Take(i + 1).ToList();
		                }
		                else
		                {
			                lstInst = SessionHelper.SessionControlContainer.Instructions;
		                }
					}

                    SessionHelper.Clear();
                }

                // start new session
                session = new Session()
                {
                    Status = Status.Active,
                    StartDTG = DateTime.Now
                };
                _context.Sessions.Add(session);
                _context.SaveChanges();

                // Update new sessionId
                SessionHelper.SessionControlContainer = new SessionControlContainer()
                {
                    Instructions = lstInst
                };
                SessionHelper.SessionId = session.SessionId;
				SessionHelper.Data = new Dictionary<string, object>();
            }
            else
            {
                if (SessionHelper.SessionControlContainer.Instructions.All(s => s.InstructionId != instruction.ParentInstructionId &&
                    s.InstructionId != instruction.InstructionId))
                {
                    return RedirectToActionPermanent("index", "Home");
                }
            }

            // Get data for breadcrumb
            var instructions = SessionHelper.SessionControlContainer.Instructions;
            if (instructions.All(s => s.InstructionId != id))
            {
                var icon = _context.AdmSystemParameters.FirstOrDefault(s => s.SystemParameterId == instruction.IconID);
                instructions.Add(new InstructionListItem()
                {
                    InstructionId = instruction.InstructionId,
                    Name = instruction.Name,
                    IconUrl = icon == null ? "" : "http://localhost:3934/" + Server.GetUrl(icon.Ext1)
                });
            }

            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
                ViewBag.Model = ViewData.Model;
            }

            return View(new InstructionDetailsVM()
            {
                HistoryInstructions = instructions.ToList(),
                Instruction = instruction,
                //SessionDetailsId = sessionDetailsId,
                InstructionType = GetInstructionType(instruction)
            });
        }

        private static InstructionType GetInstructionType(Instruction instruction)
        {
            if (instruction.NextInstructionId == null && instruction.SubInstructions.Any())
            {
                return InstructionType.Navigation;
            }
            return InstructionType.Entry;
        }
    }
}