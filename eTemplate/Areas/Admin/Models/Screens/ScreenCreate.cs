using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTemplate.Areas.Admin.Models.Screens
{
	public class ScreenCreate
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Url { get; set; }
		public string Description { get; set; }
		public string Thumbnail { get; set; }
	}
}