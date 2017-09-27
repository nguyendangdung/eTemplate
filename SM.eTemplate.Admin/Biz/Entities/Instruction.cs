using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SM.eTemplate.Biz.Entities
{
	public class Instruction
	{
		public int InstructionId { get; set; }
		public string Name { get; set; }
		public int? DisplayOrder { get; set; }
		public string ParentInstructionName { get; set; }
		public int? ParentInstructionId { get; set; }
		public string ScreenName { get; set; }
		public int ScreenId { get; set; }
		public string NextInstructionName { get; set; }
		public int? NextInstructionId { get; set; }
		public string PreviousInstructionName { get; set; }
		public int? PreviousInstructionId { get; set; }
		public string IconUrl { get; set; }
	}
}