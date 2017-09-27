using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Web.Biz
{
	public static class XmlHelper
	{
		public static Dictionary<string, string> GetDictionaryValue(this string data)
		{
			XDocument doc = XDocument.Parse(data);
			Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

			foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
			{
				int keyInt = 0;
				string keyName = element.Name.LocalName;

				while (dataDictionary.ContainsKey(keyName))
				{
					keyName = element.Name.LocalName + "_" + keyInt++;
				}

				dataDictionary.Add(keyName, element.Value);
			}
			return dataDictionary;
		}

		public static List<KeyValuePair<string, object>> GetProperties(this object me)
		{
			List<KeyValuePair<string, object>> result = new List<KeyValuePair<string, object>>();
			foreach (var property in me.GetType().GetProperties())
			{
				result.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(me)));
			}
			return result;
		}
	}
}