<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgressUC.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.Base.ProgressUC" %>
<%@ Register Assembly="EvolutionNet.Util" Namespace="EvolutionNet.Util.Web" TagPrefix="evolutionnet" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<script type="text/javascript" language="javascript">
	Sys.Application.add_load(DoLoad);
	var t;
	var cancelationPending = false;
	function StartProgress() {
		//var txtSlowWorkTime = $get('TxtSlowWorkTime');
		//alert('startProgress');
		CallServer2("", "");
		//ShowProgressPopup();
		if (!cancelationPending) {
			//alert('start');
			t = setTimeout(StartProgress, 100);
		}
		else {
			alert('end');
			var modalPopup = $find('ModalPopupProgress');
			modalPopup.hide();
			//clearTimeout(t);
		}
	}

	function DoStartProgress() {
		cancelationPending = false;
		StartProgress();
	}

	function DoLoad() {
		//alert('startProgress');
		cancelationPending = false;
		var modalPopup = $find('ModalPopupProgress');
		modalPopup.add_shown(DoStartProgress);
		modalPopup.add_hidden(StopProgress);
	}

	function StopProgress() {
		//alert('Stopping');
		cancelationPending = true;
		clearTimeout(t);
	}
	
	function ReceiveServerData2(result) {
		//document.getElementById("ResultsSpan").innerHTML = rValue;
		//var modalPopup = $find('ModalPopupProgress');
		//modalPopup.hide();
		//var progressBar = $find('ctl00_ctl00_ProgressUC1_ProgressBar1');
		//alert('Result: ' + result);
		var progressBar = $find(progressBarName);
		progressBar.setProgress(result);

		if (result == "100") {
			alert("Sucesso!");
			//setTimeout("alert('Sucesso!')", 100);
			progressBar.setProgress(0);
			//cancelationPending = true;
			//StopProgress();
			//CancelAsyncPostBack();
			var modalPopup = $find('ModalPopupProgress');
			modalPopup.hide();
		}
		//var txtSlowWorkTime = $get('TxtSlowWorkTime');
		//txtSlowWorkTime.value = result;
	}

	function CancelAsyncPostBack() {
		var prm = Sys.WebForms.PageRequestManager.getInstance();
		if (prm.get_isInAsyncPostBack()) {
			prm.abortPostBack();
		}
		StopProgress();
	}
</script>
<%--
<asp:UpdatePanel ID="UpdatePanelProgress" runat="server">
	<ContentTemplate>
--%>
		<asp:Panel ID="PanelProgress" CssClass="PanelEditar" runat="server" Width="400" style="display: none;">
			<div id="PanelCaption"><asp:Label ID="LblCaption" runat="server" Text="Progress" /></div>
			<div id="PanelDados">
				<asp:UpdatePanel ID="UpdatePanelProgress" runat="server">
					<ContentTemplate>
						<asp:Label ID="LblText" runat="server" Text="Executing operation..." style="text-align: center"></asp:Label>
						<evolutionnet:ProgressBar ID="ProgressBar1" runat="server" Width="375px" />
						<evolutionnet:TimeCounter ID="TimeCounter1" runat="server" StartOnLoad="False" />
						
						<div class="ClearBoth"></div>
						<div class="ActionsRight">
							<asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClientClick="CancelAsyncPostBack(); return false;"
								onclick="BtnCancel_Click" CausesValidation="False" TabIndex="6" />
						</div>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
			
		</asp:Panel>

		<asp:Button ID="Button1" runat="server" Text="Button" style="display: none;" />
		<ajaxtoolkit:ModalPopupExtender ID="ModalPopupProgress" runat="server"
			PopupControlID="PanelProgress" TargetControlID="Button1"
			BackgroundCssClass="ModalPopupBackground" BehaviorID="ModalPopupProgress" />
<%--
	</ContentTemplate>
</asp:UpdatePanel>
--%>
