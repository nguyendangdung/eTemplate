using EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SM.eTemplate.UI.Admin.Instructions
{
	public partial class Delete : System.Web.UI.Page
	{
		private int _instructionId;
		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request.QueryString["instructionId"], out _instructionId);
			if (!IsPostBack)
			{
				using (var context = new Context())
				{
					var instruction = context.Instructions.Find(_instructionId);
					if (instruction == null)
					{
						Response.Redirect("Index.aspx");
					}
				}
				
			}
		}

		protected void DeleteConfirmButtonClickedHandler(object sender, EventArgs e)
		{
			using (var context = new Context())
			{
				var instruction = context.Instructions.Include(s => s.ParentInstruction)
					.Include(s => s.SubInstructions)
					.FirstOrDefault(s => s.InstructionId == _instructionId);

				if (instruction == null)
				{
					Response.Redirect("Index.aspx");
				}
				else
				{
					instruction.SubInstructions.ToList().ForEach(s =>
					{
						s.ParentInstructionId = instruction.ParentInstructionId;
						if (s.PreviousInstructionId == instruction.InstructionId)
						{
							s.PreviousInstructionId = instruction.ParentInstructionId;
						}
					});

					context.Instructions.Remove(instruction);
					context.SaveChanges();

					Response.Redirect("Index.aspx");
				}
			}
		}
	}
}