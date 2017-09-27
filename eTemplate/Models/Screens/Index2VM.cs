using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTemplate.Models.Screens
{
	public class Index2VM : ScreenVM
	{
		public Index2Data Data { get; set; }
	}

	public class Index2Data
	{
		[Display(Name = "Họ và tên")]
		public string FullName { get; set; }

		[Display(Name = "Ngày sinh")]
		public DateTime? DayOfBirth { get; set; }

		[Display(Name = "Số CMTND")]
		public string CustomerId { get; set; }
	}
}