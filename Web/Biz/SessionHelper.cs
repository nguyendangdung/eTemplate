using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF;
using Web.Models.Instructions;

namespace Web.Biz
{
	public static class SessionHelper
	{
        //private readonly HttpSessionStateBase _session;

        //public SessionHelper(HttpSessionStateBase session)
        //{
        //    _session = session;
        //}

		private static T GetValue<T>(string key)
		{
            if (System.Web.HttpContext.Current.Session[key] == null)
			{
				return default(T);
			}

            return (T)System.Web.HttpContext.Current.Session[key];
		}

		public static void Clear()
		{
		    System.Web.HttpContext.Current.Session.Clear();
		}

		private static void SetValue(string key, object value)
		{
			if (value == null || string.IsNullOrWhiteSpace(key))
			{
				return;
			}
		    System.Web.HttpContext.Current.Session[key] = value;
		}

	    public static SessionControlContainer SessionControlContainer
	    {
            get { return GetValue<SessionControlContainer>("SessionControlContainer"); }
            set { SetValue("SessionControlContainer", value); }
	    }

	    public static int? SessionId
	    {
            get { return GetValue<int?>("SessionId"); }
            set { SetValue("SessionId", value); }
	    }

        //public static List<InstructionSessionListItem> Instructions
        //{
        //    get
        //    {
        //        if (SessionDataContainer == null) return null;
        //        return SessionDataContainer.Instructions;
        //    }
        //}

	    public static Dictionary<string, object> Data
	    {
            get { return GetValue<Dictionary<string, object>>("Data"); }
            set { SetValue("Data", value); }
	    }
	}
}