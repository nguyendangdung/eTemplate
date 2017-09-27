using System;
using System.Collections.Generic;
using System.Linq;
using EF;
using SoftMart.Core.UIControls;

namespace SM.eTemplate.UI.Admin.Instructions
{
	public partial class Instructions : System.Web.UI.MasterPage
	{
		public TreeViewExtended InstructionsTreeView { get { return _instructionsTreeView; } }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				using (var context = new Context())
				{
					var instructionId = Request.QueryString["instructionId"];
					var instructions = context.Instructions.ToList();

					//var root = new TreeNodeItem()
					//{
					//	ID = 0.ToString(),
					//	Text = "Root",
					//	Parent = null
					//};
					//_instructionsTreeView.Nodes.Add(root);
					//AddNodes(root.ID, instructions);

					var treeViewItems = instructions.Select(s => new TreeNodeItem()
					{
						Text = s.Name,
						Parent = s.ParentInstructionId == null ? "" : s.ParentInstructionId.ToString(),
						ID = s.InstructionId.ToString()
					});
					_instructionsTreeView.DataSource = treeViewItems;
					_instructionsTreeView.DataBind();


					if (instructionId != null)
					{
						var selectedNode = _instructionsTreeView.Nodes.Cast<TreeNodeItem>().FirstOrDefault(s => s.ID == instructionId);
						if (selectedNode != null)
						{
							_instructionsTreeView.SelectedNode = selectedNode;
						}
					}
				}
			}
		}

		//private void AddNodes(string id, List<Instruction> instructions)
		//{
		//	List<Instruction> child;
		//	if (id == "0")
		//	{
		//		child = instructions.Where(s => s.ParentInstructionId == null).ToList();
		//	}
		//	else
		//	{
		//	    child = instructions.Where(s => s.ParentInstructionId != null && s.ParentInstructionId.ToString() == id)
		//	        .ToList();
		//	}

		//	if (child.Any())
		//	{
		//		child.ForEach(s =>
		//		{
		//			var noteItem = new TreeNodeItem()
		//			{
		//				ID = s.InstructionId.ToString(),
		//				Parent = id,
		//				Text = s.Name
		//			};
		//			_instructionsTreeView.Nodes.Add(noteItem);
		//			AddNodes(s.InstructionId.ToString(), instructions);
		//		});
		//	}
		//}

		protected void SelectedNodeChanged(object sender, EventArgs e)
		{
			Response.Redirect("Index.aspx?instructionId=" + _instructionsTreeView.SelectedValue);
		}
	}
}