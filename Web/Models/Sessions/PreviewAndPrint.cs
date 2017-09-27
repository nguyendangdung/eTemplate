using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Sessions
{
	public class PreviewAndPrint
	{
		public IEnumerable<EF.SessionDetail> SessionDetailses { get; set; }
		public int SessionId { get; set; }
		//public int WorkFlowId { get; set; }
		public int PreviousInstructionId { get; set; }
	}
}