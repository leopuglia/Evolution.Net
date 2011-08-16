<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressBarTest2.aspx.cs" Inherits="EvolutionNet.Sample.UI.Web.Util.Web.ProgressBarTest2" %>
<%@ Register src="ProgressBarUCTest.ascx" tagname="ProgressBarUCTest" tagprefix="uc1" %>
<%@ Register Assembly="EvolutionNet.Util" Namespace="EvolutionNet.Util.Web"	TagPrefix="evolution" %>

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
		<h1>Progress Bar Test 2</h1><br/><br/>
		<h2>Progress Bar inside a UserControl</h2>
		<uc1:ProgressBarUCTest ID="ProgressBarUCTest1" runat="server" />
	</div>
	</form>
</body>
</html>
