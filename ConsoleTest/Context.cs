namespace ConsoleTest
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public class Context : DbContext
	{
		public DbSet<Session> Sessions { get; set; }
		public DbSet<WorkFlow> WorkFlows { get; set; }
		public DbSet<Screen> Screens { get; set; }
		public DbSet<WorkFlowScreen> WorkFlowScreens { get; set; }
		public DbSet<SessionData> SessionDatas { get; set; }
	    public DbSet<WorkFlowCategory> WorkFlowCategories { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		    modelBuilder.Entity<WorkFlow>().HasOptional(s => s.WorkFlowCategory).WithMany(s => s.WorkFlows)
		        .HasForeignKey(s => s.WorkFlowCategoryId);
		}
	}
}
