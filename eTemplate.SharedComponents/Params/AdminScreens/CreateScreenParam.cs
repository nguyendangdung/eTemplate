using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTemplate.SharedComponents.Constants;
using eTemplate.SharedComponents.Entities;

namespace eTemplate.SharedComponents.Params.AdminScreens
{
	public class CreateScreenParam : BaseParam
	{
		public CreateScreenParam() 
			: base(Constants.BusinessType.AdminScreens, Constants.FunctionType.AdminScreensFunction.CreateScreen)
		{
		}
		public Screen Screen { get; set; }
	}
}
