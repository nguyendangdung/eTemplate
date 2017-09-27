using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
	public class WorkFlow
	{
		public int WorkFlowId { get; set; }
		public string Name { get; set; }
		public bool IsDefault { get; set; }
		public virtual Instruction StartInstruction { get; set; }
		public int? StartInstructionId { get; set; }
	}
}
