namespace eTemplate.SharedComponents.Params
{
    public class ReportInfo
    {
        public string DisplayName { get; set; }
        /// <summary>
        /// To get from SMX.DynamicReportType.dctXmlConfigFile[dynamicReportKey]
        /// </summary>
        public string Type { get; set; }

        public ReportInfo(string displayName, string type)
        {
            this.DisplayName = displayName;
            this.Type = type;
        }
    }
}
