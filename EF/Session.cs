using System;
using System.Collections.Generic;

namespace EF
{
    public enum Status
    {
        Active, Inactive
    }
	public class Session
	{
		public int SessionId { get; set; }
		public DateTime? StartDTG { get; set; }
		public DateTime? EndDTG { get; set; }
		public Status? Status { get; set; }
		//public bool Finished { get; set; }

		//public virtual WorkFlow WorkFlow { get; set; }
		//public int WorkFlowId { get; set; }

		public virtual ICollection<SessionDetail> SessionDetails { get; set; }
	}
}