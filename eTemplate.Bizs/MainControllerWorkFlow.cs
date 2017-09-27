using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using eTemplate.Bizs.Bizs;
using eTemplate.SharedComponents.Constants;
using eTemplate.SharedComponents.Params;
using eTemplate.SharedComponents.Params.AdminWorkFlows;

namespace eTemplate.Bizs
{
	public partial class MainController
	{

		private void ExecuteWorkFlowBiz(BaseParam param)
		{
			var biz = AutofacConfig.Container.Resolve<WorkFlowBiz>();
			switch (param.FunctionType)
			{
				case FunctionType.AdminWorkFlowsFuctions.GetWorkFlows:
					biz.GetWorkFlows(param as GetWorkFlowsParam);
					break;
                case FunctionType.AdminWorkFlowsFuctions.OnCreatingWorkFlow:
                    biz.OnCreatingWorkFlow(param as OnCreatingWorkFlowParam);
			        break;
                // OnCreatingWorkFlow
				default:
					throw new Exception("FunctionType is not supported: " + param.FunctionType);
			}
		}
	}
}
