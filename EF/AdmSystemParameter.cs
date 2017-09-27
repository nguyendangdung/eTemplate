using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
	public class AdmSystemParameter
	{
		public int SystemParameterId { get; set; } // SystemParameterID (Primary key)
		public string Name { get; set; } // Name (length: 256)
		public string Description { get; set; } // Description
		public string Code { get; set; } // Code (length: 128)
		public int? Status { get; set; } // Status
		public int? Version { get; set; } // Version
		public System.DateTime? CreatedDtg { get; set; } // CreatedDTG
		public string CreatedOn { get; set; } // CreatedOn (length: 64)
		public string CreatedBy { get; set; } // CreatedBy (length: 64)
		public System.DateTime? UpdatedDtg { get; set; } // UpdatedDTG
		public string UpdatedOn { get; set; } // UpdatedOn (length: 64)
		public string UpdatedBy { get; set; } // UpdatedBy (length: 64)
		public int? DisplayOrder { get; set; } // DisplayOrder
		public int? Deleted { get; set; } // Deleted
		public int? Checked { get; set; } // Checked
		public int FeatureId { get; set; } // FeatureID (Primary key)
		public string Ext1 { get; set; } // Ext1 (length: 256)
		public string Ext2 { get; set; } // Ext2 (length: 256)
		public int? Ext1I { get; set; } // Ext1i
		public int? Ext2I { get; set; } // Ext2i
		public string Ext3 { get; set; } // Ext3 (length: 64)
		public System.DateTime? Ext4 { get; set; } // Ext4
	}
}
