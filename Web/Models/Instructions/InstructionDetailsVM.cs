using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF;

namespace Web.Models.Instructions
{
	public class InstructionDetailsVM
	{
		public List<InstructionListItem> HistoryInstructions { get; set; }
		public Instruction Instruction { get; set; }
	    public int? SessionDetailsId { get; set; }
		public InstructionType InstructionType { get; set; }
	}
}