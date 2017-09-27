using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftMart.Core.Dao;

namespace eTemplate.SharedComponents.EntityInfos
{
	public class WorkFlowScreenInfo : BaseEntity
	{
		public int WorkFlowId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }


		public int ScreenId { get; set; }
		public string ScreenName { get; set; }
		public string ScreenDescription { get; set; }
		public string ScreenUrl { get; set; }
		

		public WorkFlowScreenInfo() : base("", "", "", "")
		{
		}
	}
}
