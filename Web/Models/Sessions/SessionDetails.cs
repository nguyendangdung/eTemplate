using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF;

namespace Web.Models.Sessions
{
	public class SessionDetails
	{
		public int SessionId { get; set; }
		public int InstructionId { get; set; }
		public ActionMethod ActionMethod { get; set; }
		public int? TheNextInstructionId { get; set; }
		public int? ThePreviousInstructionId { get; set; }
	}
}