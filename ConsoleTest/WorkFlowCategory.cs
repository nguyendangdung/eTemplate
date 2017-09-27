using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class WorkFlowCategory
    {
        public int WorkFlowCategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public virtual ICollection<WorkFlow> WorkFlows { get; set; }
    }
}
