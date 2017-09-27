using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using eTemplate.Bizs.Bizs;
using eTemplate.SharedComponents.Constants;
using eTemplate.SharedComponents.Params;
using eTemplate.SharedComponents.Params.AdminScreens;

namespace eTemplate.Bizs
{
	public partial class MainController
	{
		private void ExecuteScreenBiz(BaseParam param)
		{
			var biz = AutofacConfig.Container.Resolve<ScreenBiz>();
			switch (param.FunctionType)
			{
				case FunctionType.AdminScreensFunction.GetScreenActionMethodMapper:
					biz.GetScreenActionMethodMapper(param as GetScreenActionMethodMapperParam);
					break;
				case FunctionType.AdminScreensFunction.GetNewScreenFromUrl:
					biz.GetNewScreenFromUrl(param as GetNewScreenFromUrlParam);
					break;
				case FunctionType.AdminScreensFunction.CreateScreen:
					biz.CreateScreen(param as CreateScreenParam);
					break;

				// CreateScreen
				//GetNewScreenFromUrl
				default:
					throw new Exception("FunctionType is not supported: " + param.FunctionType);
			}
		}
	}
}
