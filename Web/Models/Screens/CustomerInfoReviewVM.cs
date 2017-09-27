using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Biz;

namespace Web.Models.Screens
{
	public class CustomerInfoReviewVM : ScreenVM
	{
		public CustomerInfoReviewData Data { get; set; }
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