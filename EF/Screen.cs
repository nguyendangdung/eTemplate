using System.Collections.Generic;

namespace EF
{
	public class ActionMethod
	{
		public string Controller { get; set; }
		public string Action { get; set; }
	}

	public enum InstructionType
	{
		Navigation, Entry, Display
	}

	public class Screen
	{
		public int ScreenId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public ActionMethod ActionMethod { get; set; }
		public virtual ICollection<Instruction> Instructions { get; set; }
	}
}
