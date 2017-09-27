using System.Collections.Generic;
using System.Xml.Serialization;

namespace Web.Models.Screens
{
	public class Denomination
	{
		public string Name { get; set; }
		public int Value { get; set; }
		public int? NumberOfUnit { get; set; }

		[XmlElement(IsNullable = true)]
		public string Note { get; set; }
		public static List<Denomination> Denominations()
		{
			return new List<Denomination>()
			{
				new Denomination()
				{
					Name = "",
					Value = 10000
				},
				new Denomination()
				{
					Name = "",
					Value = 20000
				},
				new Denomination()
				{
					Name = "",
					Value = 50000
				},
				new Denomination()
				{
					Name = "",
					Value = 100000
				},
				new Denomination()
				{
					Name = "",
					Value = 200000
				},
				new Denomination()
				{
					Name = "",
					Value = 500000
				}
			};
		}
	}
}