using eTemplate.SharedComponents.Constants;
using SoftMart.Kernel.Entity;

namespace eTemplate.SharedComponents.Params
{
	//Khong ai duoc them bat cu gi vao day. BaseParam giu nho nhat co the
    public abstract class BaseParam
    {
        public BusinessType BusinessType { get; private set; }
        public string FunctionType { get; set; }

        public PagingInfo PagingInfo { get; set; }
        public ReportInfo ReportInfo { get; set; }

        protected BaseParam(BusinessType businessType, string functionType)
        {
            BusinessType = businessType;
            FunctionType = functionType;
        }
    }
}
