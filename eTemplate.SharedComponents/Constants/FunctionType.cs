using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTemplate.SharedComponents.Constants
{
	public class FunctionType
	{
		public class AdminScreensFunction
		{
			public const string GetScreenActionMethodMapper = "GetScreenActionMethodMapper";
			public const string GetNewScreenFromUrl = "GetNewScreenFromUrl";
			public const string CreateScreen = "CreateScreen";
		}


		public class AdminWorkFlowsFuctions
		{
			public const string GetWorkFlows = "GetWorkFlows";
            public const string OnCreatingWorkFlow = "OnCreatingWorkFlow";
		}

	}
}
