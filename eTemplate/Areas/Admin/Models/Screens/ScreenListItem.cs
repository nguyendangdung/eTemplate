using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTemplate.Areas.Admin.Models.Screens
{
	public class ScreenListItem
	{
		public int ScreenId { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
	}
}