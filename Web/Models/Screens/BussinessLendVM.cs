using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Screens
{
	public class BussinessLendData
	{
		[Display(Name = "Tên công ty")]
		public string CompanyName { get; set; }

		[Display(Name = "Địa chỉ")]
		public string Address { get; set; }
		[Display(Name = "Mã số thuế")]
		public string TaxRegistrationNumber { get; set; }
		[Display(Name = "Số tiền muốn vay")]
		public long? Amount { get; set; }
	}

	public class BussinessLendVM : ScreenVM
	{
		public BussinessLendData Data { get; set; }
		public override string GetData()
		{
			return Data.XmlSerializeToString();
		}

		public override List<KeyValuePair<string, object>> GetKeyValuePair()
		{
			return base.GetKeyValuePair();
		}
	}
}