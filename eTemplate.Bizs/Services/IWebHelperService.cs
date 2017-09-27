using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTemplate.Bizs.Services
{
	public interface IWebHelperService
	{
		string GetUrlFromPhysicalPath(string path);


		string GetHost();

		/// <summary>
		/// reutrn https://abc.vn/test/123 from test/123
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		string GetFullUrlFromRelativeUrl(string url);
	}
}
