using System.Web;

namespace Web.Biz
{
	public static class Helper
	{
		public static int? GetInt(this string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			var result = 0;
			return int.TryParse(text, out result) ? result : (int?)null;
		}

		public static string GetUrl(this HttpServerUtility server, string path)
		{
			return string.Format("/{0}",
				path.ToLower().Replace(server.MapPath("/").ToLower(), "").Replace(@"\", "/"));
		}

		public static string GetUrl(this HttpServerUtilityBase server, string path)
		{
			return string.Format("/{0}",
				path.ToLower().Replace(server.MapPath("/").ToLower(), "").Replace(@"\", "/"));
		}
	}
}