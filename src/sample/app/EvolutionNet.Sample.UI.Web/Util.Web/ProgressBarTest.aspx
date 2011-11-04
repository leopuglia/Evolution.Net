<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressBarTest.aspx.cs" Inherits="EvolutionNet.Sample.UI.Web.Util.Web.ProgressBarTest" %>
<%@ Register Assembly="EvolutionNet.Util" Namespace="EvolutionNet.Util.Web"	TagPrefix="evolutionnet" %>
<%@ Register src="ProgressBarUCTest.ascx" tagname="ProgressBarUCTest" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Progress Bar Test</title>
	<style type="text/css">
		.box	  { border:5px solid #00f; width:400px; height:40px; font-size: 20px; }
/*		.box div { background-color: Black; height: 40px;}*/
		.bar	 { background:#ccc; }
		.text  { font-family: Verdana; }
	</style>
</head>
<body>
	<form id="form1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" />
	<div>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<h1>Progress Bar Test</h1><br/><br/>
				<h2>Progress Bar with AutoProgress set on Page Load event. Buttons with client calls.</h2>
				<evolutionnet:ProgressBar ID="ProgressBar1" runat="server" />
				<asp:Button ID="Button1" runat="server" OnClientClick="$find('ProgressBar1').startAutoProgress(); return false;" Text="Run" />
				<asp:Button ID="Button2" runat="server" OnClientClick="$find('ProgressBar1').stopAutoProgress(); return false;" Text="Stop" />
				<hr /><br/>
				
				<h2>Progress Bar with AutoProgress set on property. Buttons with client calls.</h2>
				<evolutionnet:ProgressBar ID="ProgressBar2" runat="server" AutoProgress="True" ShowPercentualText="False" />
				<asp:Button ID="Button7" runat="server" OnClientClick="$find('ProgressBar2').startAutoProgress(); return false;" Text="Run" />
				<asp:Button ID="Button8" runat="server" OnClientClick="$find('ProgressBar2').stopAutoProgress(); return false;" Text="Stop" />
				<hr /><br/>
				
				<h2>Progress Bar with Css classes set and a custom percentual format. Buttons with client calls.</h2>
				<evolutionnet:ProgressBar ID="ProgressBar3" CssClass="box" CssClassBar="bar" CssClassPercentual="text" runat="server" PercentualFormat="{0}% (client calls)" />
				<asp:Button ID="Button3" runat="server" OnClientClick="$find('ProgressBar3').stepProgress(10); return false;" Text="Add 10%" />
				<asp:Button ID="Button4" runat="server" OnClientClick="$find('ProgressBar3').stepProgress(-10); return false;" Text="Remove 10%" />
				<asp:Button ID="Button5" runat="server" OnClientClick="$find('ProgressBar3').startAutoProgress(); return false;" Text="Run" />
				<asp:Button ID="Button6" runat="server" OnClientClick="$find('ProgressBar3').stopAutoProgress(); return false;" Text="Stop" />
				<hr /><br/>
				
			</ContentTemplate>
		</asp:UpdatePanel>
		
		<h2>Progress Bar inside a UserControl</h2>
		<uc1:ProgressBarUCTest ID="ProgressBarUCTest1" runat="server" />
	</div>
	</form>
</body>
</html>
