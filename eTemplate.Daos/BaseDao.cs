using System.Collections.Generic;
using System.Data.SqlClient;
using SoftMart.Kernel.Entity;

namespace eTemplate.Daos
{
    public abstract class BaseDao
    {
        protected string BuildLikeFilter(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return null;
            return string.Format("%{0}%", keyword.Trim());
        }

        protected string BuildInCondition(List<int> lstValue)
        {
            if (lstValue.Count == 0)
            {
                return "null";
            }
            else
            {
                return string.Join(", ", lstValue.ToArray());
            }
        }

        protected string BuildInCondition(List<string> lstValue)
        {
            if (lstValue.Count == 0)
            {
                return "null";
            }
            else
            {
                string result = string.Empty;
                string separator = string.Empty;

                foreach (string item in lstValue)
                {
                    result += separator + "'" + item.Trim().Replace("'", "''") + "'";
                    separator = ",";
                }
                return result;
            }
        }

        protected List<T> ExecutePaging<T>(DataContext dataContext, SqlCommand command, string orderStatement, PagingInfo pagingInfo)
        {
            int recordCord;
            List<T> lst = dataContext.ExecutePaging<T>(command, pagingInfo.PageIndex, pagingInfo.PageSize, orderStatement, out recordCord);
            pagingInfo.RecordCount = recordCord;
            return lst;
        }

        protected List<T> ExecutePaging<T>(DataContext dataContext, string query, string orderStatement, PagingInfo pagingInfo)
        {
            SqlCommand sqlCmd = new SqlCommand(query);

            return ExecutePaging<T>(dataContext, sqlCmd, orderStatement, pagingInfo);
        }

        protected System.Data.DataTable ExecuteDataTablePaging(DataContext dataContext, SqlCommand sqlCmd, string orderStatement, PagingInfo pagingInfo)
        {
            int recordCord;
            System.Data.DataTable data = dataContext.ExecuteDataTable(sqlCmd, pagingInfo.PageIndex, pagingInfo.PageSize, orderStatement, out recordCord);
            pagingInfo.RecordCount = recordCord;

            return data;
        }
    }
}
