using System;
using eTemplate.SharedComponents;
using eTemplate.SharedComponents.Constants;
using eTemplate.SharedComponents.Params;
using SoftMart.Core.Utilities.Diagnostics;

namespace eTemplate.Bizs
{
	public partial class MainController
	{
		private static MainController _provider;
		private MainController() { }

		public static MainController Provider
		{
			get { return _provider != null ? _provider : (_provider = new MainController()); }
		}


		public void Execute(BaseParam baseParam)
		{
			try
			{
				if (baseParam == null) throw new ArgumentNullException();
				switch (baseParam.BusinessType)
				{
					case BusinessType.AdminScreens:
						ExecuteScreenBiz(baseParam);
						break;
					case BusinessType.AdminWorkFlows:
						ExecuteWorkFlowBiz(baseParam);
						break;
					//case BusinessType.Account:
					//	ExecuteAccountBiz(baseParam);
					//	break;
					//case BusinessType.TransportationRequest:
					//	ExecuteTransportationRequestBiz(baseParam);
					//	break;
					//case BusinessType.User:
					//	ExecuteUserBiz(baseParam);
					//	break;
					//case BusinessType.Chat:
					//	ExcuteChatBiz(baseParam);
					//	break;
					default:
						throw new Exception("BusinessType is not supported");
				}
			}
			catch (Exception ex)
			{
				string message = string.Format("MainController.Execute({0}, {1})", baseParam.BusinessType, baseParam.FunctionType);
				LoggerManager.GetLogger("Savar").LogDebug(message, ex);
				throw;
			}
		}
	}
}
