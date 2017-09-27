<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/Instructions/Instructions.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SM.eTemplate.UI.Admin.Instructions.Edit" %>
<%@ Register TagPrefix="cc1" Namespace="SoftMart.Core.UIControls" Assembly="SMCUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="text-right">
		<a href="Index.aspx" class="btn btn-primary btn-sm">Cancel</a>
		<asp:Button ID="SaveButton" 
					OnClick="SaveButtonClickedHandler" 
					runat="server" 
					Text="Save" />
	</div>
	
	<div class="form-horizontal">
		<div class="form-group">
			<label class="col-sm-2 control-label">Parent</label>
			<div class="col-sm-10">
				<asp:Label ID="_parentInstructionNameLabel" CssClass="form-control-static" runat="server" Text=""></asp:Label>
			</div>
		</div>
		<div class="form-group">
			<label for="inputEmail3" class="col-sm-2 control-label">Name</label>
			<div class="col-sm-10">
				<asp:TextBox ID="_instructionNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
			</div>
		</div>
		
		<div class="form-group">
			<label for="inputEmail3" class="col-sm-2 control-label">Order</label>
			<div class="col-sm-10">
				<cc1:NumericTextBox ID="_instructionDisplayOrderNumericTextBox" runat="server" CssClass="form-control"/>
			</div>
		</div>
		
		<div class="form-group">
			<label for="inputEmail3" class="col-sm-2 control-label">Icon</label>
			<div class="col-sm-10">
				<asp:DropDownList runat="server" OnSelectedIndexChanged="InstructionIconSelectionChanged" ID="_instructionIconDropdownList" CssClass="form-control" AutoPostBack="True"/>
			</div>
		</div>
		
		<div class="form-group">
			<label for="inputEmail3" class="col-sm-2 control-label"></label>
			<div class="col-sm-10">
				<asp:Image ID="_instructionIconImage" runat="server" />
			</div>
		</div>

		<div class="form-group">
			<label for="inputEmail3" class="col-sm-2 control-label">Screen</label>
			<div class="col-sm-10">
				<asp:DropDownList CssClass="form-control" 
								ID="_instructionScreenDropDownList" runat="server"></asp:DropDownList>
			</div>
		</div>
		
		<div class="form-group">
			<label for="inputEmail3" class="col-sm-2 control-label">Previous</label>
			<div class="col-sm-10">
				<asp:DropDownList CssClass="form-control" 
								ID="_previousInstructionDropDownList" runat="server"></asp:DropDownList>
			</div>
		</div>
	</div>
</asp:Content>
