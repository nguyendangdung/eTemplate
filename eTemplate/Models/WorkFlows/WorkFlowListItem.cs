using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eTemplate.Areas.Admin.Models.Screens;

namespace eTemplate.Models.WorkFlows
{
	public class WorkFlowListItem
	{
		public int WorkFlowId { get; set; }
		public List<ScreenListItem> Screens { get; set; }
	}
}