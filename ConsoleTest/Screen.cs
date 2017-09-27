using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
	public class ActionMethod
	{
		public string Controller { get; set; }
		public string Action { get; set; }
	}
	public class Screen
	{
		public int ScreenId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ActionMethod ActionMethod { get; set; }

	}
}
