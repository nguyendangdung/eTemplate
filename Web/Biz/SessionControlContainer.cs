using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Instructions;

namespace Web.Biz
{
    public class SessionControlContainer
    {
        //public int SessionId { get; set; }
        public List<InstructionListItem> Instructions { get; set; }
        //public Dictionary<string, object> Data { get; set; }
    }
}