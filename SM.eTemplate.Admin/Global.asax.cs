using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using AutoMapper;
using EF;
//using SM.eTemplate.SharedComponent.Constants;
//using SM.eTemplate.Utils;
//using SM.eTemplate.CacheManager;
using SoftMart.Service.Reporting;

namespace SM.eTemplate
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {

	        MapConfiguration();
	        /*
			// Code that runs on application startup

			GlobalCache.ReloadCache();

			string appCnnKey = SMX.ConnectionString.ApplicationData;

			//Use SqlTransaction
			SoftMart.Core.Dao.TransactionScope.Config(appCnnKey);

			// Config Ranking service
			//SoftMart.Core.Ranking.RankingEngineAPI.ConfigService(appCnnKey, appCnnKey);

			//Config BatchProcessing
			//BatchProcessingApi.ConfigService(appCnnKey);

			// Config dynamic report
			SoftMart.Service.Reporting.ReportingApi.ConfigService(appCnnKey, appCnnKey, ConfigUtils.DynamicReportFolder, ConfigUtils.TemplateFolder, ConfigUtils.TemporaryFolder);

			// Caching for dynamic report
			List<ForeignKeyData> lstForeignKey = GlobalCache.CacheSystemParamenter.Select(en =>
				new ForeignKeyData(en.SystemParameterID.ToString(), en.Code, en.Name)).ToList();
			SoftMart.Service.Reporting.ReportingApi.SetForeignKeyData(lstForeignKey);


			////Config Notification
			//var mailServerInfo = new SoftMart.Service.Notification.Entity.MailServerInfo()
			//{
			//    Host = ConfigUtils.EmailHost,
			//    Port = ConfigUtils.EmailPort,
			//    UserName = ConfigUtils.EmailUserName,
			//    Password = ConfigUtils.EmailPassword,
			//    EnableSsl = ConfigUtils.EmailEnableSSL,
			//    From = ConfigUtils.EmailFrom
			//};
			//string temporaryFolder = ConfigUtils.TemporaryFolder;
			//SoftMart.Service.Notification.NotificationApi.ConfigService(appCnnKey, temporaryFolder,
			//                                                            null,
			//                                                            mailServerInfo,
			//                                                            null);//LogManager.ServiceNotification);

			//// Setting for workflow
			//WorkflowApi.ConfigService(appCnnKey, appCnnKey);

			// Code that runs on application startup
			Dictionary<int, string> dctRule = new Dictionary<int, string>();
			foreach (int key in SMX.RuleCategory.dicValue.Keys)
			{
				dctRule.Add(key, SMX.RuleCategory.dicValue[key]);
			}
			SoftMart.Core.BRE.RuleEngineService.ConfigureService(appCnnKey, appCnnKey, dctRule);

			////SHC
			//SoftMart.Service.SHC.SHCApi.ConfigService(appCnnKey, "Web", null);
			//new SoftMart.Service.SHC.SHCServiceThread().StartService();

			//// Export
			//System.Threading.Thread exportingThread = new System.Threading.Thread(new System.Threading.ThreadStart(ProcessExportData));
			//exportingThread.Start();
			*/
        }

	    private void MapConfiguration()
	    {
		    Mapper.Initialize(cfg =>
		    {
			    cfg.CreateMap<Instruction, Biz.Entities.Instruction>();
		    });
	    }

	    void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
