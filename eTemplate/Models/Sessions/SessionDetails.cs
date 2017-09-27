using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTemplate.Models.Sessions
{
	public class SessionDetails
	{
		public int SessionId { get; set; }
		public SessionDataListItem PreviousSessionData { get; set; }
		public SessionDataListItem CurrentSessionData { get; set; }
		public SessionDataListItem NextSessionData { get; set; }
	}
}