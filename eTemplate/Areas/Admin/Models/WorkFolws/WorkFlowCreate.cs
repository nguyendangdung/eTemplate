using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eTemplate.Areas.Admin.Models.Screens;

namespace eTemplate.Areas.Admin.Models.WorkFolws
{
	public class WorkFlowCreate
	{
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
	    public IEnumerable<ScreenListItem> Screens { get; set; }
		public IEnumerable<ScreenListItem> SelectedScreens { get; set; }
	}
}