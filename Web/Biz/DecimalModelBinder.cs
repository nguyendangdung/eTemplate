using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Web.Biz
{
    public class IntegerModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult == null)
            {
                return null;
            }
            var modelState = new ModelState { Value = valueResult };
            object actualValue = null;

            try
            {
                var textNoDot = valueResult.AttemptedValue.Replace(".", "");
                var temp = 0;
                if (int.TryParse(textNoDot, out temp))
                {
                    actualValue = temp;
                }
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }

	public class DecimalModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
		    if (valueResult == null)
		    {
		        return null;
		    }
			var modelState = new ModelState { Value = valueResult };
			long actualValue = 0;

			try
			{
				var aa = valueResult.AttemptedValue.Replace(".", "");
			    long.TryParse(aa, out actualValue);
			}
			catch (FormatException e)
			{
				modelState.Errors.Add(e);
			}

			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			return actualValue;
		}
	}
}