using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Biz;

namespace Web.Models.Screens
{
	public class CustomerInfoReviewData
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string AccountNumber { get; set; }
		public decimal Balance { get; set; }
		public CustomerType CustomerType { get; set; }
	}
}