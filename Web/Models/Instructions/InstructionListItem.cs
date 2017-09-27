using EF;

namespace Web.Models.Instructions
{
	public class InstructionListItem
	{
		public int InstructionId { get; set; }
		public string Name { get; set; }
		public InstructionType InstructionType { get; set; }
		public string IconUrl { get; set; }
	}
}