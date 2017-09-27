using System.Collections.Generic;

namespace eTemplate.Areas.Admin.Models.Screens
{
	public class ScreenList
	{
		public IEnumerable<ScreenListItem> Screens { get; set; }
		public IEnumerable<ActionMethod> ActionMethods { get; set; }
	}
}