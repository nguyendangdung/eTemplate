using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
	public class WorkFlowScreen
	{
		public int WorkFlowScreenId { get; set; }
		public int Order { get; set; }

		public int WorkFlowId { get; set; }
		public virtual WorkFlow WorkFlow { get; set; }
		public int ScreenId { get; set; }
		public virtual Screen Screen { get; set; }
	}
}
