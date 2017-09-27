using System.Collections.Generic;
using Web.Biz;
namespace Web.Models.Screens
{
	public class MoneyDetailsVM : ScreenVM
	{
		public MoneyDetailsData Data { get; set; }

		public MoneyDetailsVM()
		{
			Data = new MoneyDetailsData()
			{
				Denominations = Denomination.Denominations()
			};
		}

		public override string GetData()
		{
			return Data.XmlSerializeToString();
		}

		public override List<KeyValuePair<string, object>> GetKeyValuePair()
		{
			return Data.GetProperties();
		}
	}
}