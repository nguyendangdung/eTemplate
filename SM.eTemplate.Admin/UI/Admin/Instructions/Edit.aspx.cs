using EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SM.eTemplate.Biz;

namespace SM.eTemplate.UI.Admin.Instructions
{
	public partial class Edit : System.Web.UI.Page
	{
		private int _instructionId;
		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request.QueryString["instructionId"], out _instructionId);
			if (!IsPostBack)
			{
				if (_instructionId > 0)
				{
					using (var context = new Context())
					{
						var instruction = context.Instructions.Include(s => s.ParentInstruction).Include(s => s.Screen)
							.FirstOrDefault(s => s.InstructionId == _instructionId);
						if (instruction == null)
						{
							Response.Redirect("Index.aspx");
						}
						else
						{
							_parentInstructionNameLabel.Text = instruction.ParentInstruction.Name;
							_instructionNameTextBox.Text = instruction.Name;
							_instructionDisplayOrderNumericTextBox.Text = instruction.DisplayOrder.ToString();

							var screens = context.Screens.ToList();
							_instructionScreenDropDownList.Items.AddRange(screens.Select(s => new ListItem()
							{
								Text = s.Name,
								Value = s.ScreenId.ToString()
							}).ToArray());
							_instructionScreenDropDownList.SelectedValue = instruction.ScreenId.ToString();

							// Load Icons
							var icons = context.AdmSystemParameters.Where(s => s.FeatureId == 2001);
							_instructionIconDropdownList.Items.Add(new ListItem() { Text = "Chọn một hình ...", Value = "" });
							_instructionIconDropdownList.Items.AddRange(icons.Select(s => new ListItem()
							{
								Text = s.Ext1,
								Value = s.SystemParameterId.ToString()
							}).ToArray());

							var selectedIcon = icons.FirstOrDefault(s => instruction.IconID == s.SystemParameterId);
							if (selectedIcon != null)
							{
								_instructionIconDropdownList.SelectedValue = selectedIcon.SystemParameterId.ToString();
								_instructionIconImage.ImageUrl = Server.GetUrl(selectedIcon.Ext1);
							}

                            //string appPath = Server.MapPath("/").ToLower();
                            //var a = string.Format("/{0}",
                            //    icons.FirstOrDefault() == null
                            //        ? ""
                            //        : icons.FirstOrDefault().Ext1.ToLower().Replace(appPath, "").Replace(@"\", "/"));

							// Previous
							var all = context.Instructions.ToList();
							var pre = Add.GetPreviousInstructions(all, instruction.ParentInstruction);

							_previousInstructionDropDownList.Items.AddRange(pre.Select(s => new ListItem()
							{
								Text = s.Name,
								Value = s.InstructionId.ToString()
							}).ToArray());
							_previousInstructionDropDownList.SelectedValue = instruction.PreviousInstructionId.ToString();
						}
					}
				}
				else
				{
					Response.Redirect("Index.aspx");
				}
			}
		}

		protected void SaveButtonClickedHandler(object sender, EventArgs e)
		{
			using (var context = new Context())
			{
				var instruction = context.Instructions.Find(_instructionId);
				if (instruction == null)
				{
					Response.Redirect("Index.aspx");
				}
				else
				{
					instruction.Name = _instructionNameTextBox.Text;
					instruction.DisplayOrder = _instructionDisplayOrderNumericTextBox.Text.GetInt();
					//instruction.InstructionType = (InstructionType) (int.Parse(_instructionTypeDropDownList.SelectedValue));
					instruction.ScreenId = _instructionScreenDropDownList.SelectedValue.GetInt().GetValueOrDefault();
					instruction.PreviousInstructionId = _previousInstructionDropDownList.SelectedValue.GetInt();
					instruction.IconID = _instructionIconDropdownList.SelectedValue.GetInt();
					context.SaveChanges();
					Response.Redirect("Index.aspx?instructionId=" + instruction.InstructionId);
				}
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