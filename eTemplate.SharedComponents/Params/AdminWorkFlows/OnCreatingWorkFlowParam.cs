using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTemplate.SharedComponents.Constants;
using eTemplate.SharedComponents.Entities;

namespace eTemplate.SharedComponents.Params.AdminWorkFlows
{
    public class OnCreatingWorkFlowParam : BaseParam
    {
        public OnCreatingWorkFlowParam()
            : base(Constants.BusinessType.AdminWorkFlows, Constants.FunctionType.AdminWorkFlowsFuctions.OnCreatingWorkFlow)
        {
        }

        public IEnumerable<Screen> Screens { get; set; }
    }
}
