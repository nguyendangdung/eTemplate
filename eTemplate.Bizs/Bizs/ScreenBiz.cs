using System;
using System.Linq;
using eTemplate.Bizs.Services;
using eTemplate.Daos;
using eTemplate.SharedComponents.Entities;
using eTemplate.SharedComponents.Params.AdminScreens;

namespace eTemplate.Bizs.Bizs
{
	public class ScreenBiz
	{
		private readonly ScreenDao _screenDao = new ScreenDao();
		private readonly IActionMethodService _actionMethodService;
		private readonly ISystemConfigSerivce _systemConfigSerivce;
		private readonly IWebHelperService _webHelperService;
		private readonly IThumbnailHelperService _thumbnailHelperService;

		public ScreenBiz(IActionMethodService actionMethodService, ISystemConfigSerivce systemConfigSerivce, IWebHelperService webHelperService, IThumbnailHelperService thumbnailHelperService)
		{
			_actionMethodService = actionMethodService;
			_systemConfigSerivce = systemConfigSerivce;
			_webHelperService = webHelperService;
			_thumbnailHelperService = thumbnailHelperService;
		}

		public void GetScreenActionMethodMapper(GetScreenActionMethodMapperParam param)
		{
			var screens = _screenDao.GetAll();
			param.Screens = screens;
			param.ActionMethodInfos = _actionMethodService.GetActionMethodInfos();
		}

		public void GetNewScreenFromUrl(GetNewScreenFromUrlParam param)
		{
			// Check input URL empty
			if (string.IsNullOrWhiteSpace(param.Url))
			{
				throw new Exception();
			}

			// Check input URL exist in the current action method set
			var actionMethod = _actionMethodService.GetActionMethodInfos().FirstOrDefault(s => s.Url == param.Url);
			if (actionMethod == null)
			{
				throw new Exception();
			}

			// Generate thumbnail from input URL
			var thumbnailPhysicalPath = _thumbnailHelperService.GetThumbnail(param.Url);
			var thumbnailUrl = _webHelperService.GetUrlFromPhysicalPath(thumbnailPhysicalPath);

			param.ThumbnailUrl = thumbnailUrl;
			param.Screen = new Screen()
			{
				Url = param.Url,
				Name = actionMethod.Name
			};
		}

		public void CreateScreen(CreateScreenParam param)
		{
			_screenDao.InsertScreen(param.Screen);
		}
	}
}
