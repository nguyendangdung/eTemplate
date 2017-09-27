using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTemplate.Bizs.Services
{
	public interface ISystemConfigSerivce
	{
		string ThumbnailStoreDirectory { get; }
	}

	public class WebConfigSystemConfigSerivce : ISystemConfigSerivce
	{
		public string ThumbnailStoreDirectory { get; private set; }
	}

	public class HardCodeSystemConfigSerivce : ISystemConfigSerivce
	{
		public string ThumbnailStoreDirectory { get; private set; }

		public HardCodeSystemConfigSerivce()
		{
			ThumbnailStoreDirectory = @"D:\projects\eTemplate\eTemplate\Images";
		}
	}
}
