using System;
using System.IO;
using System.Net.Http;
using System.Web;
using eTemplate.Bizs.Services;

namespace eTemplate.Services
{
	public class WebHelperService : IWebHelperService
	{
		public string GetUrlFromPhysicalPath(string path)
		{
			if (File.Exists(path) || Directory.Exists(path))
			{
				var request = HttpContext.Current.Request;
				var url = path.Replace(request.ServerVariables["APPL_PHYSICAL_PATH"], "/").Replace(@"\", "/");
				return url;
			}
			return "";
		}

		public string GetHost()
		{
			var request = HttpContext.Current.Request;
			var uri = new UriBuilder(request.Url.Scheme, request.Url.Host, request.Url.Port);
			return uri.ToString();
		}

		public string GetFullUrlFromRelativeUrl(string url)
		{
			return new UriBuilder(GetHost(), url).ToString();
		}
	}
}