using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftMart.Core.Dao;

namespace eTemplate.SharedComponents.Entities
{

	public class WorkFlow : BaseEntity
	{
		#region Primitive members

		public const string C_WorkFlowId = "WorkFlowId"; // 
		private int? _WorkFlowId;
		[PropertyEntity(C_WorkFlowId, true)]
		public int? WorkFlowId
		{
			get { return _WorkFlowId; }
			set { _WorkFlowId = value; NotifyPropertyChanged(C_WorkFlowId); }
		}

		public const string C_Name = "Name"; // 
		private string _Name;
		[PropertyEntity(C_Name, false)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; NotifyPropertyChanged(C_Name); }
		}

		public const string C_Description = "Description"; // 
		private string _Description;
		[PropertyEntity(C_Description, false)]
		public string Description
		{
			get { return _Description; }
			set { _Description = value; NotifyPropertyChanged(C_Description); }
		}


		public WorkFlow() : base("WorkFlow", "WorkFlowId", "", "") { }

		#endregion

		#region Extend members

		#endregion
	}

}
