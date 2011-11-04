<%@ Page Title="Start Page" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EvolutionNet.Sample.UI.Web.Default" Async="true" %>
<%@ Register src="CategoryCrudView.ascx" tagname="CategoryCrudView" tagprefix="uc1" %>
<asp:Content ID="Head" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>
<asp:Content ID="Breadcrumb" ContentPlaceHolderID="BreadcrumbHolder" runat="server">
	Start 
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentHolder" runat="server">
	<h2>Start Page</h2>
	<uc1:CategoryCrudView ID="CategoryCrudView1" runat="server" />
</asp:Content>
