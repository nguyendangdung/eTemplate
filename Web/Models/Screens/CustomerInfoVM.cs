using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Web.Biz;

namespace Web.Models.Screens
{
	public class CustomerInfoVM : ScreenVM
	{
		public CustomerInfoData Data { get; set; }
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