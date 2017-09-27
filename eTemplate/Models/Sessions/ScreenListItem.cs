using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsoleTest;

namespace eTemplate.Models.Sessions
{
	public class ScreenListItem
	{
		public int ScreenId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ActionMethod ActionMethod { get; set; }
	}
}