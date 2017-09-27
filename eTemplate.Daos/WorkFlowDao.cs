using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTemplate.SharedComponents.Entities;
using eTemplate.SharedComponents.EntityInfos;
using SoftMart.Kernel.Exceptions;

namespace eTemplate.Daos
{

	public class WorkFlowDao : BaseDao
	{
		#region Modification methods

		public void InsertWorkFlow(WorkFlow item)
		{
			using (DataContext dataContext = new DataContext())
			{
				dataContext.InsertItem<WorkFlow>(item);
			}
		}

		public void UpdateWorkFlow(WorkFlow item)
		{
			int affectedRows;
			using (DataContext dataContext = new DataContext())
			{
				affectedRows = dataContext.UpdateItem<WorkFlow>(item);
			}
			if (affectedRows == 0)
			{
				throw new SMXException(Messages.Common.ItemChanged);
			}
		}

		#endregion

		#region Getting methods

		public WorkFlow GetWorkFlowByID(int id)
		{
			using (DataContext dataContext = new DataContext())
			{
				return dataContext.SelectItemByID<WorkFlow>(id);
			}
		}

		#endregion

		#region Searching methods

		//public void SearchWorkFlow(WorkFlowParam param)
		//{

		//}

		#endregion

		public IEnumerable<WorkFlow> GetAll()
		{
			var q = @"
SELECT WorkFlowId ,
       Name ,
       Description
FROM   WorkFlow;
";

			using (var cmd = new SqlCommand(q))
			{
				using (var context = new DataContext())
				{
					return context.ExecuteSelect<WorkFlow>(cmd);
				}
			}
		}

		public IEnumerable<WorkFlowScreenInfo> GetWorkFlowScreenInfos()
		{
			var q = @"
SELECT WorkFlow.WorkFlowId ,
       WorkFlow.Name ,
       WorkFlow.Description ,
       Screen.ScreenId ,
       Screen.Name AS ScreenName ,
       Screen.Description AS ScreenDescription ,
       Screen.Url AS ScreenUrl
FROM   WorkFlow
       INNER JOIN WorkFlowScreen ON WorkFlow.WorkFlowId = WorkFlowScreen.WorkFlowId
       INNER JOIN Screen ON WorkFlowScreen.ScreenId = Screen.ScreenId
";
			using (var cmd = new SqlCommand(q))
			{
				using (var context = new DataContext())
				{
					return context.ExecuteSelect<WorkFlowScreenInfo>(cmd);
				}
			}
		}
	}
}
