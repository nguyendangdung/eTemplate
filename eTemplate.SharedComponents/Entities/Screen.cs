
using SoftMart.Core.Dao;

namespace eTemplate.SharedComponents.Entities
{

	public class Screen : BaseEntity
	{
		#region Primitive members

		public const string C_ScreenId = "ScreenId"; // 
		private int? _ScreenId;
		[PropertyEntity(C_ScreenId, true)]
		public int? ScreenId
		{
			get { return _ScreenId; }
			set { _ScreenId = value; NotifyPropertyChanged(C_ScreenId); }
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

		public const string C_Url = "Url"; // 
		private string _Url;
		[PropertyEntity(C_Url, false)]
		public string Url
		{
			get { return _Url; }
			set { _Url = value; NotifyPropertyChanged(C_Url); }
		}


		public Screen() : base("Screen", "ScreenId", "", "") { }

		#endregion

		#region Extend members

		#endregion
	}

}
