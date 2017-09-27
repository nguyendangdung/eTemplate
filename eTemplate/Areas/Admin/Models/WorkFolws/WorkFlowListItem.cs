using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eTemplate.Areas.Admin.Models.Screens;

namespace eTemplate.Areas.Admin.Models.WorkFolws
{
	public class WorkFlowListItem
	{
		public int WorkFlowId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public IEnumerable<ScreenListItem> Screens { get; set; }
	}
}