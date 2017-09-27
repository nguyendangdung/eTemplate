using System;
using eTemplate.SharedComponents.Entities;

namespace eTemplate.SharedComponents.Params.AdminScreens
{
	public class GetNewScreenFromUrlParam : BaseParam
	{
		public GetNewScreenFromUrlParam() 
			: base(Constants.BusinessType.AdminScreens, Constants.FunctionType.AdminScreensFunction.GetNewScreenFromUrl)
		{
		}

		public string Url { get; set; }
		public Screen Screen { get; set; }
		public string ThumbnailUrl { get; set; }
	}
}