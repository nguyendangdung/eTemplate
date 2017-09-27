using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Web.Biz;
using Web.Models.Screens;

namespace Web.Test
{
	[TestFixture]
	public class TypeTest
	{
		[Test]
		public void Test()
		{
			//ScreenVM vm = new CustomerInfoVM()
			//{

			//};

			//var data = vm.

			////var type = vm.GetType();
			//var customerData = new CustomerInfoData()
			//{
			//	AccountNumber = "123",
			//	CustomerName = "!23"
			//};

			//var dic = customerData.GetProperties();

			string text = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fffffff",
				CultureInfo.InvariantCulture);

			Assert.Fail();
		}
	}
}
