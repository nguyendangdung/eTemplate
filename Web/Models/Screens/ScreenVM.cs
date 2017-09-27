using System.Collections.Generic;
using EF;

namespace Web.Models.Screens
{
	public class ScreenVM
	{
		public Instruction Instruction { get; set; }
		public NavigationButton NavigationButton { get; set; }
		public virtual string GetData()
		{
			return "";
		}

		public virtual List<KeyValuePair<string, object>> GetKeyValuePair()
		{
			return new List<KeyValuePair<string, object>>();
		}
	}
}