<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/Instructions/Instructions.master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="SM.eTemplate.UI.Admin.Instructions.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="text-right">
		<a href="Index.aspx" class="btn btn-primary btn-sm">Cancel</a>
		<asp:Button ID="_deleteConfirmButton" 
					OnClick="DeleteConfirmButtonClickedHandler" 
					runat="server" 
					Text="Delete" />
	</div>
	<div>
		<h1>Bạn có chắc muốn xóa?</h1>
	</div>
</asp:Content>
