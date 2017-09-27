using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTemplate.Models.Screens
{
	public enum Currency
	{
		USD, VND
	}
	public class Index3VM : ScreenVM
	{
		public Index3Data Data { get; set; }
	}

	public class Index3Data
	{
		[Display(Name = "Họ và tên")]
		public string FullName { get; set; }

		[Display(Name = "Số tiền")]
		public decimal? AmountExpected { get; set; }
		[Display(Name = "Số tiền bằng chữ")]
		public string AmountExpectedByText { get; set; }

		[Display(Name = "Đơn vị")]
		public Currency Currency { get; set; }
	}
}