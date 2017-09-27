using System.Collections.Generic;

namespace ConsoleTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleTest.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ConsoleTest.Context context)
        {

	        var cate1 = new WorkFlowCategory()
	        {
		        Name = "Cá nhân",
		        DisplayText = "Cá nhân"
	        };

	        var cate2 = new WorkFlowCategory()
	        {
		        Name = "Doanh nghiệp",
		        DisplayText = "Doanh nghiệp"
	        };

	        context.WorkFlowCategories.AddOrUpdate(s => s.Name, cate1, cate2);
	        context.SaveChanges();


	        var index1 = new Screen()
	        {
		        Name = "index",
		        Description = "index",
		        ActionMethod = new ActionMethod()
		        {
			        Action = "index",
			        Controller = "screens"
		        }
	        };
	        var index2 = new Screen()
	        {
		        Name = "index2",
		        Description = "index2",
		        ActionMethod = new ActionMethod()
		        {
			        Action = "index2",
			        Controller = "screens"
		        }
	        };
	        var index3 = new Screen()
	        {
		        Name = "index3",
		        Description = "index3",
		        ActionMethod = new ActionMethod()
		        {
			        Action = "index3",
			        Controller = "screens"
		        }
	        };
	        var index4 = new Screen()
	        {
		        Name = "index4",
		        Description = "index4",
		        ActionMethod = new ActionMethod()
		        {
			        Action = "index4",
			        Controller = "screens"
		        }
	        };

	        context.Screens.AddOrUpdate(s => s.Name, index4, index3, index2, index1);
	        context.SaveChanges();

			var persionalWithdraw = new WorkFlow()
			{
				Name = "Cá nhân rút tiền",
				Description = "Cá nhân rút tiền",
				WorkFlowCategoryId = cate1.WorkFlowCategoryId
			};

	        var persionalDeposit = new WorkFlow()
	        {
		        Name = "Cá nhân nạp tiền",
		        Description = "Cá nhân nạp tiền",
		        WorkFlowCategoryId = cate1.WorkFlowCategoryId
	        };


	        var businessWithdraw = new WorkFlow()
	        {
		        Name = "Doanh nghiệp rút tiền",
		        Description = "Doanh nghiệp rút tiền",
		        WorkFlowCategoryId = cate2.WorkFlowCategoryId
	        };

	        var businessDeposit = new WorkFlow()
	        {
		        Name = "Doanh nghiệp nạp tiền",
		        Description = "Doanh nghiệp nạp tiền",
		        WorkFlowCategoryId = cate2.WorkFlowCategoryId
	        };

	        context.WorkFlows.AddOrUpdate(s => s.Name, persionalDeposit, persionalWithdraw, businessDeposit,
		        businessWithdraw);
	        context.SaveChanges();

			var wfScreen1 = new WorkFlowScreen()
			{
				Order = 1,
				Screen = index1,
				WorkFlow = persionalWithdraw
			};
	        var wfScreen2 = new WorkFlowScreen()
	        {
				Order = 2,
		        Screen = index2,
				WorkFlow = persionalWithdraw
			};
	        var wfScreen3 = new WorkFlowScreen()
	        {
				Order = 3,
		        Screen = index3,
		        WorkFlow = persionalWithdraw
			};



	        var wfScreen4 = new WorkFlowScreen()
	        {
				Order = 1,
		        Screen = index1,
		        WorkFlow = persionalDeposit
			};
	        var wfScreen5 = new WorkFlowScreen()
	        {
				Order = 2,
		        Screen = index2,
		        WorkFlow = persionalDeposit
			};
	        var wfScreen6 = new WorkFlowScreen()
	        {
				Order = 3,
		        Screen = index4,
		        WorkFlow = persionalDeposit
			};

	        context.WorkFlowScreens.AddOrUpdate(s => new {s.WorkFlowId, s.ScreenId}, wfScreen1, wfScreen2, wfScreen3,
		        wfScreen4, wfScreen5, wfScreen6);
	        context.SaveChanges();
		}
    }
}
