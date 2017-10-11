using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Web.Biz;
using Web.Models.Sessions;
using Web.MvcRazorToPdf;

namespace Web.Controllers
{
	public class BasketItem
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
	public class PdfExample
	{
		public string Heading { get; set; }
		public IEnumerable<BasketItem> Items { get; set; }
	}
	public class SessionsController : Controller
    {
	    private readonly Context _context = new Context();
        // GET: Sessions
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">SessionId</param>
		/// <param name="instructionId">if = null => Get the first instruction</param>
		/// <returns></returns>
        public ActionResult Index(int id, int? instructionId)
		{
			throw new NotImplementedException();
			//var session = _context.Sessions
			//	.FirstOrDefault(s => s.SessionId == id && s.Status == Status.Active);
			//if (session == null)
			//{
			//	throw new Exception();
			//}

			//Instruction instruction;
			//if (instructionId == null)
			//{
			//	instruction = session.WorkFlow.StartInstruction;
			//}
			//else
			//{
			//	instruction = _context.Instructions.Find(instructionId);
			//}
			//if (instruction == null)
			//{
			//	throw new Exception();
			//}


			//if (instruction.InstructionType == InstructionType.Navigation && !instruction.SubInstructions.Any())
			//{
			//	if (instruction.NextInstructionId == null)
			//	{
			//		throw new Exception();
			//	}
			//	return RedirectToAction("Index", new {id, instructionId = instruction.NextInstructionId});
			//}
			//var screen = instruction.Screen;
			//if (screen == null)
			//{
			//	throw new Exception();
			//}
			//var vm = new Models.Sessions.SessionDetails()
			//{
			//	SessionId = session.SessionId,
			//	InstructionId = instruction.InstructionId,
			//	ActionMethod = screen.ActionMethod,
			//	TheNextInstructionId = instruction.NextInstructionId,
			//	ThePreviousInstructionId = instruction.PreviousInstructionId
			//};
   //         return View(vm);
        }

	    /// <summary>
	    /// Return view + iframe show PDF
	    /// </summary>
	    /// <param name="id">SessionId</param>
	    /// <param name="previousInstructionId"></param>
	    /// <param name="wfId"></param>
	    /// <returns></returns>
	    public ActionResult PreviewAndPrint(int id, int previousInstructionId)
	    {
		    var session = _context.Sessions
				.FirstOrDefault(s => s.SessionId == id && s.Status == Status.Active);
		    var instruction = _context.Instructions.Find(previousInstructionId);
		    if (instruction == null) throw new Exception();
		    if (session == null) throw new Exception();

		    var sessionDetails = session.SessionDetails;
		    var vm = new PreviewAndPrint()
		    {
				SessionDetailses = sessionDetails,
				SessionId = id,
				PreviousInstructionId = previousInstructionId,
				//WorkFlowId = wfId
		    };

			return View(vm);
	    }

	    /// <summary>
	    /// Return pure PDF
	    /// </summary>
	    /// <param name="id">SessionId</param>
	    /// <param name="previousInstructionId"></param>
	    /// <returns></returns>
	    public ActionResult Pdf(int id, int previousInstructionId)
	    {
	        var templateDir = Path.Combine(HttpRuntime.AppDomainAppPath, "Templates");
		    var session = _context.Sessions
			    .FirstOrDefault(s => s.SessionId == id && s.Status == Status.Active);
		    var instruction = _context.Instructions.Find(previousInstructionId);
		    if (instruction == null) throw new Exception();
		    if (session == null) throw new Exception();

		    var sessionDetails = session.SessionDetails;
			//var xmlHelper = new XmlHelper();
		    var dics = sessionDetails.Select(s => s.Data.GetDictionaryValue());
			var dic = new Dictionary<string, string>();
			dics.ToList().ForEach(s =>
			{
				dic = dic.Union(s).ToDictionary(k => k.Key, v => v.Value);
			});
			dic = dic.GroupBy(d => d.Key)
			 .ToDictionary(d => d.Key, d => d.First().Value);

		    var lastInstruction = sessionDetails.OrderByDescending(s => s.SessionDetailId).Select(s => s.Instruction)
			    .FirstOrDefault();
		    if (lastInstruction == null)
		    {
			    throw new Exception();
		    }

			

			var pdfHelper = new PDFHelper();

		    if (lastInstruction.Name == "Thông tin công ty")
		    {
                pdfHelper.GenFile(Path.Combine(templateDir, "PhieuVayTien.docx"), dic, Path.Combine(templateDir, "PhieuVayTien.pdf"));
                return File(Path.Combine(templateDir, "PhieuVayTien.pdf"), "application/pdf");
                //pdfHelper.GenFile(@"D:\projects\eTemplate2\Web\Templates\PhieuVayTien.docx", dic, @"D:\projects\eTemplate2\Web\Templates\PhieuVayTien.pdf");
                //return File(@"D:\projects\eTemplate2\Web\Templates\PhieuVayTien.pdf", "application/pdf");
            }


	        pdfHelper.GenFile(Path.Combine(templateDir, "PhieuRutTien.docx"), dic, Path.Combine(templateDir, "PhieuRutTien.pdf"));
	        return File(Path.Combine(templateDir, "PhieuRutTien.pdf"), "application/pdf");
   //         pdfHelper.GenFile(@"D:\projects\eTemplate2\Web\Templates\PhieuRutTien.docx", dic, @"D:\projects\eTemplate2\Web\Templates\PhieuRutTien.pdf");
			//return File(@"D:\projects\eTemplate2\Web\Templates\PhieuRutTien.pdf", "application/pdf");
		}
	}
}