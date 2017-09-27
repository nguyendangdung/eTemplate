using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTemplate.Models.Screens
{
	public class IndexVM : ScreenVM
	{
		public IndexData Data { get; set; }
	}

	public class IndexData
	{
		[Display(Name = "Số tài khoản")]
		public string AccountNumber { get; set; }
	}
}