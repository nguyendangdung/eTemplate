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
	public class ScreenDao : BaseDao
	{
		#region Modification methods

		public void InsertScreen(Screen item)
		{
			using (DataContext dataContext = new DataContext())
			{
				dataContext.InsertItem<Screen>(item);
			}
		}

		public void UpdateScreen(Screen item)
		{
			int affectedRows;
			using (DataContext dataContext = new DataContext())
			{
				affectedRows = dataContext.UpdateItem<Screen>(item);
			}
			if (affectedRows == 0)
			{
				throw new SMXException(Messages.Common.ItemChanged);
			}
		}

		#endregion

		#region Getting methods

		public Screen GetScreenByID(int id)
		{
			using (DataContext dataContext = new DataContext())
			{
				return dataContext.SelectItemByID<Screen>(id);
			}
		}

		#endregion

		#region Searching methods

		//public void SearchScreen(ScreenParam param)
		//{

		//}

		#endregion

		public IEnumerable<Screen> GetAll()
		{
			var q = @"
SELECT ScreenId ,
       Name ,
       Description ,
       Url
FROM   Screen
";
			using (var cmd = new SqlCommand(q))
			{
				using (var context = new DataContext())
				{
					return context.ExecuteSelect<Screen>(cmd);
				}
			}

		}

		public IEnumerable<Screen> GetByWorkFlowId(int workflowId)
		{
			var q = @"
SELECT Screen.ScreenId ,
       Screen.Name ,
       Screen.Description ,
       Screen.Url
FROM   Screen
       INNER JOIN WorkFlowScreen ON Screen.ScreenId = WorkFlowScreen.ScreenId
WHERE  WorkFlowScreen.WorkFlowId = @WorkFlowId;
";

			using (var cmd = new SqlCommand(q))
			{
				cmd.Parameters.AddWithValue("@WorkFlowId", workflowId);
				using (var context = new DataContext())
				{
					return context.ExecuteSelect<Screen>(cmd);
				}
			}
		}
	}


}
