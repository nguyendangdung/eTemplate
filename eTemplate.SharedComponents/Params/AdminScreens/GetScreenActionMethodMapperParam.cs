using System;
using System.Collections.Generic;
using eTemplate.SharedComponents.Constants;
using eTemplate.SharedComponents.Entities;
using eTemplate.SharedComponents.EntityInfos;

namespace eTemplate.SharedComponents.Params.AdminScreens
{
	public class GetScreenActionMethodMapperParam : BaseParam
	{
		public GetScreenActionMethodMapperParam() : 
			base(BusinessType.AdminScreens, Constants.FunctionType.AdminScreensFunction.GetScreenActionMethodMapper)
		{
		}

		public IEnumerable<Screen> Screens { get; set; }
		public IEnumerable<ActionMethodInfo> ActionMethodInfos { get; set; }
	}
}
