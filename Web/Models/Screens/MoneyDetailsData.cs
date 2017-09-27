using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Screens
{
	public class MoneyDetailsData
	{
		[Display(Name = "Số tiền")]
		public long? Amount { get; set; }
		public List<Denomination> Denominations { get; set; }
	}
}