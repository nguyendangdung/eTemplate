using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
	public class AdmSystemParameterConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AdmSystemParameter>
	{
		//public AdmSystemParameterConfiguration()
		//	: this("dbo")
		//{
		//}

		public AdmSystemParameterConfiguration()
		{
			ToTable("adm_SystemParameter");
			HasKey(x => new { x.SystemParameterId, x.FeatureId });

			Property(x => x.SystemParameterId).HasColumnName(@"SystemParameterID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
			Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsOptional();
			Property(x => x.Code).HasColumnName(@"Code").HasColumnType("nvarchar").IsOptional().HasMaxLength(128);
			Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsOptional();
			Property(x => x.Version).HasColumnName(@"Version").HasColumnType("int").IsOptional();
			Property(x => x.CreatedDtg).HasColumnName(@"CreatedDTG").HasColumnType("datetime").IsOptional();
			Property(x => x.CreatedOn).HasColumnName(@"CreatedOn").HasColumnType("nvarchar").IsOptional().HasMaxLength(64);
			Property(x => x.CreatedBy).HasColumnName(@"CreatedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(64);
			Property(x => x.UpdatedDtg).HasColumnName(@"UpdatedDTG").HasColumnType("datetime").IsOptional();
			Property(x => x.UpdatedOn).HasColumnName(@"UpdatedOn").HasColumnType("nvarchar").IsOptional().HasMaxLength(64);
			Property(x => x.UpdatedBy).HasColumnName(@"UpdatedBy").HasColumnType("nvarchar").IsOptional().HasMaxLength(64);
			Property(x => x.DisplayOrder).HasColumnName(@"DisplayOrder").HasColumnType("int").IsOptional();
			Property(x => x.Deleted).HasColumnName(@"Deleted").HasColumnType("int").IsOptional();
			Property(x => x.Checked).HasColumnName(@"Checked").HasColumnType("int").IsOptional();
			Property(x => x.FeatureId).HasColumnName(@"FeatureID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
			Property(x => x.Ext1).HasColumnName(@"Ext1").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
			Property(x => x.Ext2).HasColumnName(@"Ext2").HasColumnType("nvarchar").IsOptional().HasMaxLength(256);
			Property(x => x.Ext1I).HasColumnName(@"Ext1i").HasColumnType("int").IsOptional();
			Property(x => x.Ext2I).HasColumnName(@"Ext2i").HasColumnType("int").IsOptional();
			Property(x => x.Ext3).HasColumnName(@"Ext3").HasColumnType("nvarchar").IsOptional().HasMaxLength(64);
			Property(x => x.Ext4).HasColumnName(@"Ext4").HasColumnType("datetime").IsOptional();
		}
	}
}
