<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressBarTest3.aspx.cs" Inherits="EvolutionNet.Sample.UI.Web.ProgressBarTest3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title></title>
	<style type="text/css">
		#box	  { border:1px solid #ccc; width:200px; height:20px; }
		#perc	 { background:#ccc; height:20px; width: 50%; position: relative; z-index: 1; }
		#display  { width: 100%; float: left; position: relative; text-align: center; z-index: 2; }
	</style>
	<script type="text/javascript" language="javascript">
		var t;

		var p = 0;
		var text = '{0}%';

		function setProgress(progress) {
			if (progress < 0 || progress > 100)
				throw ('Value should be between 0 and 100');
			p = progress;

			document.getElementById('perc').style.width = progress.toString() + '%';
			document.getElementById('display').innerHTML = text.replace('{0}', progress);
		}

		function stepProgress(step) {
			setProgress(p + step);
		}

		function setAutoProgress(step, time) {
			if (step == null)
				step = 1;
			if (time == null)
				time = 20;
			if (p == 100)
				p = 0;
			stepProgress(step);
			t = setTimeout('setAutoProgress(' + step + ',' + time + ')', time);
		}

		function cancelTimer() {
			clearTimeout(t);
		}
		
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div>
	<asp:ScriptManager ID="ScriptManager1" runat="server" />
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<asp:Label id="LblProgress" runat="server" />
<%--
			<div id="box">
				<div id="display">0%</div>
				<div id="perc"></div>
			</div>
--%>
			<input type="button" id="BtnRun" value="Run" onclick="setAutoProgress(1, 20)" />
			<input type="button" id="BtnStop" value="Stop" onclick="cancelTimer()">
			<input type="button" id="BtnAdd" value="Add 10%" onclick="stepProgress(10)" />
			<input type="button" id="BtnRemove" value="Remove 10%" onclick="stepProgress(-10)" />
			<asp:Button ID="Button1" runat="server" Text="Add 10% (server)" onclick="Button1_Click" />
			<asp:Button ID="Button2" runat="server" Text="Remove 10% (server)" onclick="Button2_Click" />
		</ContentTemplate>
	</asp:UpdatePanel>
	</div>
	
	</form>
</body>
</html>
