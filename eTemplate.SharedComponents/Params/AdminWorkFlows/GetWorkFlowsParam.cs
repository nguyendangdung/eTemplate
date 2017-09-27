using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTemplate.SharedComponents.Constants;
using eTemplate.SharedComponents.Entities;
using eTemplate.SharedComponents.EntityInfos;

namespace eTemplate.SharedComponents.Params.AdminWorkFlows
{
	public class GetWorkFlowsParam : BaseParam
	{
		public GetWorkFlowsParam() 
			: base(Constants.BusinessType.AdminWorkFlows, Constants.FunctionType.AdminWorkFlowsFuctions.GetWorkFlows)
		{
		}

		public IEnumerable<WorkFlowScreenInfo> WorkFlowScreenInfos { get; set; }
	}
}
