using SoftMart.Core.Utilities.Diagnostics;

namespace eTemplate.Daos
{
    public class DataContext : SoftMart.Core.Dao.EnterpriseService
    {
        private readonly PLogger _logger;
        public DataContext()
            : base("Context")
        {
            var callerName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
            _logger = new PLogger(string.Format("DataContext - {0}", callerName));
        }

        public override void Dispose()
        {
            base.Dispose();
            _logger.Dispose();
        }

        // private static Monitor Monitor = new ConnectionMonitor(SMX.ConnectionString.ApplicationData, "Application Connections", "Connections to application database");
    }
}
