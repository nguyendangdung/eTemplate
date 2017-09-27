using System.ComponentModel.DataAnnotations;

namespace Web.Models.Screens
{
	public class CustomerInfoData
	{
		[Display(Name = "Họ và tên")]
		public string CustomerName { get; set; }
		[Display(Name = "Số tài khoản")]
		public string AccountNumber { get; set; }
	}
}