<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeCounterTest.aspx.cs" Inherits="EvolutionNet.Sample.UI.Web.Util.Web.TimeCounterTest" %>
<%@ Register assembly="EvolutionNet.Util" namespace="EvolutionNet.Util.Web" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TimeCounter Test</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <h1>TimeCounter Test</h1>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<h2>
					<cc1:TimeCounter ID="TimeCounter1" runat="server" ShowHours="True" ShowMilliseconds="True"
						StartButtonResetCounter="True" StartButtonID="BtnRestart" StopButtonID="BtnStop" />
				</h2>
				<br />
				<asp:Button ID="BtnStop" runat="server" Text="Stop" />
				<asp:Button ID="BtnRestart" runat="server" Text="Restart" />
				<asp:Button ID="BtnTest1" runat="server" Text="Test Postback" />
				<h3>
					<cc1:TimeCounter ID="TimeCounter2" runat="server" StartButtonID="BtnContinue" StopButtonID="BtnPause" 
						ShowHours="False" ShowMilliseconds="False" />
				</h3>
				<br />
				<asp:Button ID="BtnPause" runat="server" Text="Pause" />
				<asp:Button ID="BtnContinue" runat="server" Text="Continue" />
				<asp:Button ID="BtnTest2" runat="server" Text="Test Postback" />
			</ContentTemplate>
		</asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
