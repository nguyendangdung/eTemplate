using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Biz;

namespace Web.Test
{
	[TestFixture]
	public class PDFHelperTestClass
	{
		[Test]
		public void TestMethod()
		{
			var helper = new PDFHelper();
			helper.Demo();
			// TODO: Add your test code here
			Assert.Pass("Your first passing test");
		}
	}
}
