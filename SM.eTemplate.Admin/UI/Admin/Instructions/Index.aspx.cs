using System;
using System.Data.Entity;
using System.Linq;
using EF;
using SM.eTemplate.Biz;

namespace SM.eTemplate.UI.Admin.Instructions
{
	public partial class Index : System.Web.UI.Page
	{
		public Biz.Entities.Instruction Instruction { get; private set; }
		public int? InstructionId;
		public Instructions MasterPage
		{
			get { return (Instructions)Master; }
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString["instructionId"] != null)
				{
					InstructionId = int.Parse(Request.QueryString["instructionId"]);
					using (var context = new Context())
					{
						var instruction = context.Instructions.Include(s => s.Screen)
							.Include(s => s.ParentInstruction)
							.Include(s => s.PreviousInstruction)
							.Include(s => s.NextInstruction)
							.FirstOrDefault(s => s.InstructionId == InstructionId);
						Instruction = instruction == null
							? new SM.eTemplate.Biz.Entities.Instruction()
							: AutoMapper.Mapper.Map<SM.eTemplate.Biz.Entities.Instruction>(instruction);

						if (instruction != null && instruction.IconID != null)
						{
							var icon = context.AdmSystemParameters.FirstOrDefault(s => s.SystemParameterId == instruction.IconID);
							if (icon != null && !string.IsNullOrWhiteSpace(icon.Ext1))
							{
								Instruction.IconUrl = Server.GetUrl(icon.Ext1);
							}
						}
					}
				}
				else
				{
					Instruction = new SM.eTemplate.Biz.Entities.Instruction();
				}
			}
		}

		protected void AddInstructionButtonClickedHandler(object sender, EventArgs e)
		{
			var selectedInstruction = MasterPage.InstructionsTreeView.SelectedNode;
			if (selectedInstruction != null)
			{
				Response.Redirect("Add.aspx?instructionId=" + selectedInstruction.ID);
			}
		}

		protected void EditInstructionButtonClickedHandler(object sender, EventArgs e)
		{
			var selectedInstruction = MasterPage.InstructionsTreeView.SelectedNode;
			if (selectedInstruction != null)
			{
				Response.Redirect("Edit.aspx?instructionId=" + selectedInstruction.ID);
			}
		}
	}
}