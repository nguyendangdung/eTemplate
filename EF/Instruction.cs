using System.Collections.Generic;

namespace EF
{
	public class Instruction
	{
		public int InstructionId { get; set; }
		public string Name { get; set; }
		public int? DisplayOrder { get; set; }
		//public InstructionType InstructionType { get; set; }
		public int? IconID { get; set; }
		public bool IsDefault { get; set; }
		public virtual Instruction ParentInstruction { get; set; }
		public int? ParentInstructionId { get; set; }
		public virtual Screen Screen { get; set; }
		public int ScreenId { get; set; }
		public virtual ICollection<Instruction> SubInstructions { get; set; }
		public virtual ICollection<SessionDetail> SessionDetails { get; set; }


		public virtual Instruction NextInstruction { get; set; }
		public int? NextInstructionId { get; set; }

		public virtual Instruction PreviousInstruction { get; set; }
		public int? PreviousInstructionId { get; set; }
	}
}
