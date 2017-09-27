using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
	public class Context : DbContext
	{
		public DbSet<Session> Sessions { get; set; }
		public DbSet<Screen> Screens { get; set; }
		public DbSet<SessionDetail> SessionDetails { get; set; }
		public DbSet<Instruction> Instructions { get; set; }
		public DbSet<AdmSystemParameter> AdmSystemParameters { get; set; }
		public Context()
		{
            //Database.SetInitializer<Context>(new EF.Migrations.ContextInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Instruction>().HasOptional(s => s.ParentInstruction).WithMany(s => s.SubInstructions)
				.HasForeignKey(s => s.ParentInstructionId);
			modelBuilder.Entity<Instruction>().HasOptional(s => s.NextInstruction)
				.WithMany().HasForeignKey(s => s.NextInstructionId);
			modelBuilder.Entity<Instruction>().HasOptional(s => s.PreviousInstruction)
				.WithMany().HasForeignKey(s => s.PreviousInstructionId);

			modelBuilder.Configurations.Add(new AdmSystemParameterConfiguration());
		}
	}
}
