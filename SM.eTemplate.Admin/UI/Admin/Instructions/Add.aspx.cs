using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EF;
using SM.eTemplate.Biz;
using SoftMart.Core.UIControls;

namespace SM.eTemplate.UI.Admin.Instructions
{
	public partial class Add : System.Web.UI.Page
	{
		
		public Instruction ParentInstruction { get; set; }
		private int _parentInstructionId;

		public Instructions MasterPage
		{
			get { return (Instructions) Master; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request.QueryString["instructionId"], out _parentInstructionId);
			if (!IsPostBack)
			{
				using (var context = new Context())
				{
					ParentInstruction = context.Instructions.Find(_parentInstructionId);
					//_parentInstructionNameLabel.Text = _parentInstruction == null ? "" : _parentInstruction.Name;
					// Load screens
					var screens = context.Screens.ToList();
					screens.ForEach(s =>
					{
						_screensDropDownList.Items.Add(new ListItem()
						{
							Text = s.Name,
							Value = s.ScreenId.ToString()
						});
					});

					// Load Icons
					var icons = context.AdmSystemParameters.Where(s => s.FeatureId == 2001);
					_instructionIconDropdownList.Items.Add(new ListItem(){Text = "Chọn một hình ...", Value = ""});
					_instructionIconDropdownList.Items.AddRange(icons.Select(s => new ListItem()
					{
						Text = s.Ext1,
						Value = s.SystemParameterId.ToString()
					}).ToArray());

					//string appPath = Server.MapPath("/").ToLower();
					//var a = string.Format("/{0}", icons.FirstOrDefault()?.Ext1.ToLower().Replace(appPath, "").Replace(@"\", "/"));

					//_instructionIconImage.ImageUrl = a;

					// Previous
					var all = context.Instructions.ToList();
					var pre = GetPreviousInstructions(all, ParentInstruction);

					_previousInstructionDropDownList.Items.AddRange(pre.Select(s => new ListItem()
					{
						Text = s.Name,
						Value = s.InstructionId.ToString()
					}).ToArray());
				}
			}
		}

		public static List<Instruction> GetPreviousInstructions(List<Instruction> all, Instruction parentInstruction)
		{
			var result = new List<Instruction>();
			if (parentInstruction != null)
			{
				result.Add(parentInstruction);
				if (parentInstruction.ParentInstruction != null)
				{
					result.AddRange(GetPreviousInstructions(all, parentInstruction.ParentInstruction));
				}
			}
			
			return result;
		}

		protected void SaveButtonClickedHandler(object sender, EventArgs e)
		{
			using (var context = new Context())
			{
				Instruction instruction;
				var parentInstruction = context.Instructions.Find(_parentInstructionId);
				if (parentInstruction == null)
				{
					instruction = new Instruction()
					{
						//InstructionType = (InstructionType) int.Parse(_instructionTypeDropDownList.SelectedValue),
						ScreenId = _screensDropDownList.SelectedValue.GetInt().GetValueOrDefault(),
						Name = _instructionNameTextBox.Text,
						DisplayOrder = _instructionDisplayOrderNumericTextBox.Text.GetInt(),
						PreviousInstructionId = _previousInstructionDropDownList.SelectedValue.GetInt(),
						IconID = _instructionIconDropdownList.SelectedValue.GetInt()
					};
				}
				else
				{
					instruction = new Instruction()
					{
						//InstructionType = (InstructionType) int.Parse(_instructionTypeDropDownList.SelectedValue),
						ScreenId = int.Parse(_screensDropDownList.SelectedValue),
						Name = _instructionNameTextBox.Text,
						DisplayOrder = _instructionDisplayOrderNumericTextBox.Text.GetInt(),
						PreviousInstructionId = _previousInstructionDropDownList.SelectedValue.GetInt(),
						ParentInstructionId = parentInstruction.InstructionId,
						IconID = _instructionIconDropdownList.SelectedValue.GetInt()
					};
					parentInstruction.NextInstruction = instruction;
				}
				context.Instructions.Add(instruction);
				context.SaveChanges();

				Response.Redirect("Index.aspx?instructionId=" + instruction.InstructionId);
			}
		}

		protected void InstructionIconSelectionChanged(object sender, EventArgs e)
		{
			var id = _instructionIconDropdownList.SelectedValue.GetInt();
			if (id == null)
			{
				_instructionIconImage.ImageUrl = "";
			}
			else
			{
				using (var context = new Context())
				{
					var icon = context.AdmSystemParameters.Where(s => s.FeatureId == 2001)
						.FirstOrDefault(s => s.SystemParameterId == id);
					if (icon != null)
					{
						var a = string.Format("/{0}", icon.Ext1.ToLower().Replace(Server.MapPath("/").ToLower(), "").Replace(@"\", "/"));

						_instructionIconImage.ImageUrl = a;
					}
					else
					{
						_instructionIconImage.ImageUrl = "";
					}
				}
			}
			
		}
	}
}