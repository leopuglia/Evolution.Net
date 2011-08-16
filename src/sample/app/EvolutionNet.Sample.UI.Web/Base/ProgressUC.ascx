<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgressUC.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.Base.ProgressUC" %>
<%@ Register Assembly="EvolutionNet.Util" Namespace="EvolutionNet.Util.Web" TagPrefix="evolution" %>

<asp:UpdatePanel ID="UpdatePanelEdit" runat="server">
	<ContentTemplate>
	
		<div id="PanelCaption"><asp:Label ID="LblCaption" runat="server" Text="Progress" /></div>
		<div id="PanelDados" style="text-align: center;">
			<asp:Label ID="LblText" runat="server" Text="Executing operation..."></asp:Label>
			<evolution:ProgressBar ID="ProgressBar1" runat="server" />
			<div class="ClearBoth"></div>
			<div class="ActionsRight">
				<asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
					onclick="BtnCancel_Click" CausesValidation="False" TabIndex="6" />
			</div>
		</div>

	</ContentTemplate>
</asp:UpdatePanel>