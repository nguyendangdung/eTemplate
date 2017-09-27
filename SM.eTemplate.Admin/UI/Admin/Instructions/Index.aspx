<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/Instructions/Instructions.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SM.eTemplate.UI.Admin.Instructions.Index" %>
<%@ Import Namespace="SM.eTemplate.Biz" %>

<%@ Register Assembly="SMCUI" Namespace="SoftMart.Core.UIControls" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="text-right">
		<a href="Add.aspx?instructionId=<%= InstructionId %>" class="btn btn-primary">Add</a>
		<a href="Edit.aspx?instructionId=<%= InstructionId %>" class="btn btn-primary">Edit</a>
		<a href="Delete.aspx?instructionId=<%= InstructionId %>" class="btn btn-primary">Delete</a>
	</div>
	<div class="form-horizontal">
		<div class="form-group">
			<label class="col-sm-2 control-label">Parent</label>
			<div class="col-sm-10">
				<p class="form-control-static"><%= Instruction.ParentInstructionName %></p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-2 control-label">Name</label>
			<div class="col-sm-10">
				<p class="form-control-static"><%= Instruction.Name %></p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-2 control-label">Order</label>
			<div class="col-sm-10">
				<p class="form-control-static"><%= Instruction.DisplayOrder %></p>
			</div>
		</div>
		
		<div class="form-group">
			<label class="col-sm-2 control-label">Icon</label>
			<div class="col-sm-10">
				<img alt="" src="<%= Instruction.IconUrl %>" />
			</div>
		</div>
				
		<div class="form-group">
			<label class="col-sm-2 control-label">Screen</label>
			<div class="col-sm-10">
				<p class="form-control-static"><%= Instruction.ScreenName %></p>
			</div>
		</div>
				
		<div class="form-group">
			<label class="col-sm-2 control-label">Next</label>
			<div class="col-sm-10">
				<p class="form-control-static"><%= Instruction.NextInstructionName %></p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-2 control-label">Previous</label>
			<div class="col-sm-10">
				<p class="form-control-static"><%= Instruction.PreviousInstructionName %></p>
			</div>
		</div>
	</div>
</asp:Content>
