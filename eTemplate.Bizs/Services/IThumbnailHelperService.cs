namespace eTemplate.Bizs.Services
{
	public interface IThumbnailHelperService
	{
		/// <summary>
		/// Genarate thumbnail image from url
		/// </summary>
		/// <param name="url"></param>
		/// <returns>Physical path to the thumbnail</returns>
		string GetThumbnail(string url);
	}

	public class ThumbnailHelperService : IThumbnailHelperService
	{
		public string GetThumbnail(string url)
		{
			return @"D:\projects\eTemplate\eTemplate\Images\test.png";
		}
	}
}