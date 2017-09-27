using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
	public class WorkFlow
	{
		public int WorkFlowId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Session> Sessions { get; set; }

		public virtual ICollection<WorkFlowScreen> WorkFlowScreens { get; set; }

        public virtual WorkFlowCategory WorkFlowCategory { get; set; }
        public int? WorkFlowCategoryId { get; set; }
	}
}
