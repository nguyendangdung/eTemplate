using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTemplate.Models.Screens
{
	public class Index4VM : ScreenVM
	{
		public Index4Data Data { get; set; }
	}

	public class Index4Data
	{
		[Display(Name = "Câu hỏi kiểm tra")]
		public string TestQuestion { get; set; }
		[Display(Name = "Câu trả lời")]
		public string Answer { get; set; }
		[Display(Name = "Tin nhắn")]
		public string Message { get; set; }
	}
}