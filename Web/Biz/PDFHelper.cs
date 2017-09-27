using SoftMart.Core.OfficeUtilities.Word;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Web.Biz
{
    public class PDFHelper
    {
        public void Demo()
        {
            Dictionary<string, string> dicValue = new Dictionary<string, string>()
            {
                {"CustomerName", "Nguyen Van A" },
                {"AccountNumber", "123456789" },
                {"Amount", "1000000" },
                {"BM_SoTo10", "-" },
                {"BM_SoTo20", "-" },
                {"BM_SoTo50", "-" },
                {"BM_SoTo100", "1" },
                {"BM_SoTo200", "2" },
                {"BM_SoTo500", "1" },
            };
            GenFile(@"D:\projects\eTemplate\Web\Templates\PhieuRutTien.docx", 
				dicValue, @"D:\projects\eTemplate\Web\Templates\PhieuRutTien.pdf");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateFfileName"></param>
        /// <param name="dicValue">Key: Tên bookmark, Value: Giá trị bookmark</param>
        /// <param name="outputFileName"></param>
        public void GenFile(string templateFfileName, Dictionary<string, string> dicValue, string outputFileName)
        {
            using (var word = new WordWrapper(templateFfileName, true))
            {
                var lstBM = word.GetBookmarkNames();
                foreach (var bm in lstBM)
                {
	                if (!dicValue.ContainsKey(bm))
	                {
		                word.SetBookmarkValue(bm, "");
	                }
	                else
	                {
		                long number = 0;
		                var value = dicValue[bm];
		                var result = long.TryParse(value, out number);
		                if (result)
		                {
			                value = number.ToString("N0", new CultureInfo("vi-VN", false));

		                }
		                word.SetBookmarkValue(bm, value == null ? "" : value);
					}
                }

                word.SaveAsPDF(outputFileName);
            }
        }
    }
}