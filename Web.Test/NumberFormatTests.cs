using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Test
{
	[TestFixture]
	public class NumberFormatTests
	{
		[Test]
		public void TestMethod()
		{
			//NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;
			//// Gets a NumberFormatInfo associated with the en-US culture.
			////NumberFormatInfo nfi = Thread.CurrentThread.CurrentCulture.NumberFormat;

			//// Displays a value with the default separator (",").
			//Int64 myInt = 123456789;
			//Debug.WriteLine(myInt.ToString("N", nfi));

			//// Displays the same value with a blank as the separator.
			////nfi.NumberGroupSeparator = ".";
			//nfi.NumberDecimalDigits = 0;
			//Debug.WriteLine(myInt.ToString("N", nfi));
			//// TODO: Add your test code here


			var a = new CultureInfo("vi-VN", false);
			a.NumberFormat.NumberDecimalDigits = 0;
			a.NumberFormat.NumberGroupSeparator = ".";
			a.NumberFormat.NumberDecimalSeparator = ",";
			var actualValue = long.Parse("11.111", a);
			Assert.Pass("Your first passing test");
		}
	}
}
