using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;

namespace Web.Test
{
	[TestFixture]
	public class XmlTest
	{
		[Test]
		public void TestMethod()
		{
			string data = @"
<data>
<test>foo</test>
<test>foobbbbb</test>
<test>foobbbbb</test>
<test>foobbbbb</test>
<bar>123</bar>
<test>foobbbbb</test>
<test>foobbbbb</test>
<bar>123</bar>
<bar>123</bar>
<username>
	<firstname>dan</firstname>
	<lastname>nguyen</lastname>
	<password>12345</password>
</username>
</data>
";

			var dataDictionary = GetValue(data);


			Assert.Fail();
		}

		private static Dictionary<string, string> GetValue(string data)
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
	}
}
