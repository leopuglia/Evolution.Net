<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgressBarUCTest.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.Util.Web.ProgressBarUCTest" %>
<%@ Register Assembly="EvolutionNet.Util" Namespace="EvolutionNet.Util.Web"	TagPrefix="evolutionnet" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<h3>Custom progress bar color. Buttons with server calls.</h3>
		<evolutionnet:ProgressBar ID="ProgressBar1" runat="server" ProgressBarColor="Red" />
		<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Add 10%" />
		<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Remove 10%" />
	</ContentTemplate>
</asp:UpdatePanel>
