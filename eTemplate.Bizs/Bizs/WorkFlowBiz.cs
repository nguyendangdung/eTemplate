using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTemplate.Daos;
using eTemplate.SharedComponents.Params.AdminWorkFlows;

namespace eTemplate.Bizs.Bizs
{
	class WorkFlowBiz
	{
		private readonly WorkFlowDao _workFlowDao = new WorkFlowDao();
		private readonly ScreenDao _screenDao = new ScreenDao();
		public void GetWorkFlows(GetWorkFlowsParam param)
		{
			var workFlowScreenInfos = _workFlowDao.GetWorkFlowScreenInfos();
			param.WorkFlowScreenInfos = workFlowScreenInfos;
		}

	    public void OnCreatingWorkFlow(OnCreatingWorkFlowParam param)
	    {
	        // Get all Screen
	        var screens = _screenDao.GetAll();
	        param.Screens = screens;
	    }
	}
}
