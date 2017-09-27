using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTemplate.Models.Screens
{
	public class ScreenVM
	{
		public int SessionId { get; set; }
		public int? TheNextScreenId { get; set; }
		public int TheCurrentScreenId { get; set; }
		public int? ThePreviousScreenId { get; set; }
		public NavigationButton NavigationButton { get; set; }
	}
}