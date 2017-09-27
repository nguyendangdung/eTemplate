namespace EF.Migrations
{
	using System.Data.Entity;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<EF.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
	        AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EF.Context context)
        {
	        //ContextInitializer.SeedData(context);
		}
    }

	public class ContextInitializer : DropCreateDatabaseAlways<Context>
	{
		public static void SeedData(Context context)
		{
			#region Instruction
			var navigationScreen = new Screen()
			{
				Name = "navi1",
				Description = "navi1",
				ActionMethod = new ActionMethod()
				{
					Action = "navi1",
					Controller = "screens"
				}
			};

			var customerInfoScreen = new Screen()
			{
				Name = "customerInfoScreen",
				Description = "customerInfoScreen",
				ActionMethod = new ActionMethod()
				{
					Action = "customerInfo",
					Controller = "screens"
				}
			};

			var moneyDetailsScreen = new Screen()
			{
				Name = "moneyDetailsScreen",
				Description = "moneyDetailsScreen",
				ActionMethod = new ActionMethod()
				{
					Action = "MoneyDetails",
					Controller = "screens"
				}
			};

			var indexScreen2 = new Screen()
			{
				Name = "indexScreen2",
				Description = "indexScreen2",
				ActionMethod = new ActionMethod()
				{
					Action = "index2",
					Controller = "screens"
				}
			};

			var indexScreen3 = new Screen()
			{
				Name = "indexScreen3",
				Description = "indexScreen3",
				ActionMethod = new ActionMethod()
				{
					Action = "index3",
					Controller = "screens"
				}
			};

			var indexScreen4 = new Screen()
			{
				Name = "indexScreen4",
				Description = "indexScreen4",
				ActionMethod = new ActionMethod()
				{
					Action = "index4",
					Controller = "screens"
				}
			};

			var personnalInstruction = new Instruction()
			{
				Name = "Cá nhân",
				Screen = navigationScreen,
				DisplayOrder = 1,
                IconID = 1,
				// // InstructionType = InstructionType.Navigation
			};

			var personalDeposit = new Instruction()
			{
				Name = "Cá nhân nạp tiền",
				Screen = navigationScreen,
				DisplayOrder = 1,
			    IconID = 1,
				// // InstructionType = InstructionType.Navigation,
				ParentInstruction = personnalInstruction,
				PreviousInstruction = personnalInstruction
			};



			var personalWithdraw = new Instruction()
			{
				Name = "Cá nhân rút tiền",
				Screen = navigationScreen,
				DisplayOrder = 2,
			    IconID = 1,
				// // InstructionType = InstructionType.Navigation,
				ParentInstruction = personnalInstruction,
				PreviousInstruction = personnalInstruction
			};

			var personalWithdrawCash = new Instruction()
			{
				Name = "Tiền mặt",
				Screen = navigationScreen,
			    IconID = 1,
				DisplayOrder = 1,
				// // InstructionType = InstructionType.Navigation,
				ParentInstruction = personalWithdraw
			};

			var personalWithdrawTransfer = new Instruction()
			{
				Name = "Chuyển khoản",
				Screen = navigationScreen,
			    IconID = 1,
				DisplayOrder = 2,
				// // InstructionType = InstructionType.Navigation,
				ParentInstruction = personalWithdraw
			};

			var indexInstruction = new Instruction()
			{
				Name = "indexInstruction",
				Screen = customerInfoScreen,
			    IconID = 1,
				PreviousInstruction = personalWithdraw,
				NextInstruction = null,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Entry,
				ParentInstruction = personalWithdrawCash
			};

			var index2Instruction = new Instruction()
			{
				Name = "index2Instruction",
				Screen = indexScreen2,
				PreviousInstruction = indexInstruction,
				NextInstruction = null,
			    IconID = 1,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Entry,
				ParentInstruction = indexInstruction
			};






			var businessInstruction = new Instruction()
			{
				Name = "businessInstruction",
			    IconID = 1,
				Screen = navigationScreen,
				DisplayOrder = 2,
				// // InstructionType = InstructionType.Navigation
			};

			context.Instructions.AddOrUpdate(s => s.Name,
				personnalInstruction,
				personalDeposit,
				personalWithdraw,
				personalWithdrawCash,
				indexInstruction,
				index2Instruction,
				personalWithdrawTransfer,
				businessInstruction);

			context.SaveChanges();
			indexInstruction.NextInstruction = index2Instruction;

			//var wf1 = new WorkFlow()
			//{
			//	Name = "Cá nhân",
			//	IsDefault = true,
			//	StartInstruction = personnalInstruction
			//};
			//var wf2 = new WorkFlow()
			//{
			//	Name = "Doanh nghiệp",

			//};

			//context.WorkFlows.AddOrUpdate(s => s.Name, wf1, wf2);

			context.SaveChanges();

			#endregion
		}


		public static void SeedData2(Context context)
		{
			#region AppSettings

			var setting1 = new AdmSystemParameter()
			{
				FeatureId = 2001,
				Name = "Hoàn thành",
				Status = 1,
				Version = 1,
				Ext1 = "Images\\1.png"
			};
			var setting2 = new AdmSystemParameter()
			{
				FeatureId = 2001,
				Name = "Nhập thông tin",
				Status = 1,
				Version = 1,
				Ext1 = "Images\\2.png"
			};
			var setting3 = new AdmSystemParameter()
			{
				FeatureId = 2001,
				Name = "Kê khai loại tiền",
				Status = 1,
				Version = 1,
				Ext1 = "Images\\3.png"
			};
			var setting4 = new AdmSystemParameter()
			{
				FeatureId = 2001,
				Name = "Dùng Chung",
				Status = 1,
				Version = 1,
				Ext1 = "Images\\4.png"
			};

			context.AdmSystemParameters.AddOrUpdate(s => s.Name, setting4, setting3, setting2, setting1);
			context.SaveChanges();

			#endregion

			#region Screens

			var navigationScreen = new Screen()
			{
				Name = "Menu",
				Description = "Menu",
				ActionMethod = new ActionMethod()
				{
					Action = "navi1",
					Controller = "screens"
				}
			};

			var customerInfoScreen = new Screen()
			{
				Name = "Enter Customer Info",
				Description = "customerInfoScreen",
				ActionMethod = new ActionMethod()
				{
					Action = "customerInfo",
					Controller = "screens"
				}
			};

			var customerInfoReviewScreen = new Screen()
			{
				Name = "Confirm Customer Info",
				ActionMethod = new ActionMethod()
				{
					Action = "CustomerInfoReview",
					Controller = "Screens"
				},
				Description = "customerInfoReviewScreen"
			};

			var moneyDetailsScreen = new Screen()
			{
				Name = "Money Details",
				Description = "moneyDetailsScreen",
				ActionMethod = new ActionMethod()
				{
					Action = "MoneyDetails",
					Controller = "screens"
				}
			};

			var businessLendScreen = new Screen()
			{
				Name = "Business Lend",
				Description = "businessLendScreen",
				ActionMethod = new ActionMethod()
				{
					Action = "BussinessLend",
					Controller = "screens"
				}
			};


			var personnalInstruction = new Instruction()
			{
				Name = "Cá nhân",
				Screen = navigationScreen,
				DisplayOrder = 1,
			    IconID = 1,
				// // InstructionType = InstructionType.Navigation,
				IsDefault = true
			};

			var personalDeposit = new Instruction()
			{
				Name = "Nộp tiền",
				Screen = navigationScreen,
				DisplayOrder = 1,
			    IconID = 1,
				// // InstructionType = InstructionType.Navigation,
				ParentInstruction = personnalInstruction,
				PreviousInstruction = personnalInstruction
			};

			var customerInfoInstruction = new Instruction()
			{
				Name = "Thông tin tài khoản",
				Screen = customerInfoScreen,
				PreviousInstruction = personnalInstruction,
				NextInstruction = null,
			    IconID = 1,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Entry,
				ParentInstruction = personalDeposit
			};

			var customerInfoReview = new Instruction()
			{
				Name = "Thông tin tài khoản",
				Screen = customerInfoReviewScreen,
				PreviousInstruction = customerInfoInstruction,
				NextInstruction = null,
			    IconID = 1,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Display,
				ParentInstruction = customerInfoInstruction
			};

			var moneyDetailsInstruction = new Instruction()
			{
				Name = "Chi tiết tiền nộp",
				Screen = moneyDetailsScreen,
				PreviousInstruction = customerInfoInstruction,
				NextInstruction = null,
				DisplayOrder = 1,
			    IconID = 1,
				// InstructionType = InstructionType.Entry,
				ParentInstruction = customerInfoReview
			};



			var personalWithdraw = new Instruction()
			{
				Name = "Rút tiền",
				Screen = navigationScreen,
				DisplayOrder = 2,
			    IconID = 1,
				// // InstructionType = InstructionType.Navigation,
				ParentInstruction = personnalInstruction,
				PreviousInstruction = personnalInstruction
			};

			var personalWithdrawCash = new Instruction()
			{
				Name = "Tiền mặt",
				Screen = navigationScreen,
				DisplayOrder = 1,
			    IconID = 1,
				// // InstructionType = InstructionType.Navigation,
				ParentInstruction = personalWithdraw,
				PreviousInstruction = personalWithdraw
			};

			var personalWithdrawCash_customerInfoInstruction = new Instruction()
			{
				Name = "Thông tin tài khoản",
				Screen = customerInfoScreen,
				PreviousInstruction = personalWithdraw,
			    IconID = 1,
				NextInstruction = null,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Entry,
				ParentInstruction = personalWithdrawCash
			};

			var personalWithdrawCash_customerInfoInstruction_Review = new Instruction()
			{
				Name = "Thông tin tài khoản",
				Screen = customerInfoReviewScreen,
				PreviousInstruction = personalWithdrawCash_customerInfoInstruction,
				NextInstruction = null,
			    IconID = 1,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Display,
				ParentInstruction = personalWithdrawCash_customerInfoInstruction
			};

			var personalWithdrawCash_MoneyDetails = new Instruction()
			{
				Name = "Chi tiết tiền rút",
				Screen = moneyDetailsScreen,
				PreviousInstruction = personalWithdrawCash_customerInfoInstruction,
				NextInstruction = null,
			    IconID = 1,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Entry,
				ParentInstruction = personalWithdrawCash_customerInfoInstruction_Review
			};


			var personalWithdrawTransfer = new Instruction()
			{
				Name = "Chuyển khoản",
				Screen = navigationScreen,
			    IconID = 1,
				DisplayOrder = 2,
				// // InstructionType = InstructionType.Navigation,
				ParentInstruction = personalWithdraw,
				PreviousInstruction = personalWithdraw
			};

			var personalWithdrawTransfer_customerInfoInstruction = new Instruction()
			{
				Name = "Thông tin tài khoản",
				Screen = customerInfoScreen,
				PreviousInstruction = personalWithdraw,
			    IconID = 1,
				NextInstruction = null,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Entry,
				ParentInstruction = personalWithdrawTransfer
			};

			var personalWithdrawTransfer_MoneyDetails = new Instruction()
			{
				Name = "Chi tiết tiền rút",
				Screen = moneyDetailsScreen,
				PreviousInstruction = personalWithdrawTransfer_customerInfoInstruction,
				NextInstruction = null,
			    IconID = 1,
				DisplayOrder = 1,
				// InstructionType = InstructionType.Entry,
				ParentInstruction = personalWithdrawTransfer_customerInfoInstruction
			};

			context.Instructions.AddOrUpdate(s => s.Name,
				personnalInstruction,
				personalDeposit,
				customerInfoInstruction,
				customerInfoReview,
				moneyDetailsInstruction,
				personalWithdraw,
				personalWithdrawCash,
				personalWithdrawTransfer,
				personalWithdrawCash_customerInfoInstruction,
				personalWithdrawCash_customerInfoInstruction_Review,
				personalWithdrawCash_MoneyDetails,
				personalWithdrawTransfer_customerInfoInstruction,
				personalWithdrawTransfer_MoneyDetails);
			context.SaveChanges();
			customerInfoInstruction.NextInstruction = customerInfoReview;
			customerInfoReview.NextInstruction = moneyDetailsInstruction;
			personalWithdrawCash_customerInfoInstruction.NextInstruction = personalWithdrawCash_customerInfoInstruction_Review;
			personalWithdrawCash_customerInfoInstruction_Review.NextInstruction = personalWithdrawCash_MoneyDetails;
			personalWithdrawTransfer_customerInfoInstruction.NextInstruction = personalWithdrawTransfer_MoneyDetails;
			context.SaveChanges();
			#endregion


			#region Instructions

			var businessInstruction = new Instruction()
			{
				Name = "Doanh nghiệp",
			    IconID = 1,
				Screen = navigationScreen,
				DisplayOrder = 1,
				//// // InstructionType = InstructionType.Navigation
			};

			

			var businessLendInstruction = new Instruction()
			{
				Name = "Vay vốn đầu tư BDS",
				Screen = navigationScreen,
			    IconID = 1,
				DisplayOrder = 1,
				//// // InstructionType = InstructionType.Navigation,
				ParentInstruction = businessInstruction,
				PreviousInstruction = businessInstruction
			};

			var businessLendInfo = new Instruction()
			{
				Name = "Thông tin công ty",
				Screen = businessLendScreen,
				DisplayOrder = 1,
			    IconID = 1,
				//// InstructionType = InstructionType.Entry,
				ParentInstruction = businessLendInstruction,
				PreviousInstruction = businessInstruction
			};

			context.Instructions.AddOrUpdate(s => s.Name, 
				businessInstruction,
				businessLendInstruction,
				businessLendInfo);
			#endregion


			#region WorkFlow
			//var wf1 = new WorkFlow()
			//{
			//	Name = "Cá nhân",
			//	IsDefault = true,
			//	StartInstruction = personnalInstruction
			//};
			//var wf2 = new WorkFlow()
			//{
			//	Name = "Doanh nghiệp",
			//	StartInstruction = businessInstruction
			//};

			//context.WorkFlows.AddOrUpdate(s => s.Name, wf1, wf2);
			#endregion
		}

		protected override void Seed(Context context)
		{
			SeedData2(context);
		}
	}
}
