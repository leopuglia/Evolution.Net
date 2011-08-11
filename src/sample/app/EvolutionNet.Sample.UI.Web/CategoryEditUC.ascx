<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryEditUC.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.CategoryEditUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:UpdatePanel ID="updatePanelEdit" runat="server">
	<ContentTemplate>
	
        <div id="PanelCaption"><asp:Label ID="LabelCaption" runat="server" Text="Category Data" /></div>
        <div id="PanelDados">
            <asp:Label ID="lblCategoryName" runat="server" Text="Category Name"></asp:Label>
            <asp:TextBox ID="txtCategoryName" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
<%--
            <asp:RequiredFieldValidator ID="RfvNome" runat="server" ControlToValidate="TxtName"
                ErrorMessage="* campo requerido" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
--%>
            
            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" Width="390px" Rows="3" 
                TextMode="MultiLine" TabIndex="2"></asp:TextBox>
                
            <asp:Label ID="lblPicture" runat="server" Text="Picture"></asp:Label>
			<cc1:AsyncFileUpload ID="filePicture" runat="server" ThrobberID="imgFileLoading"
				onuploadedcomplete="filePicture_UploadedComplete" OnClientUploadComplete="UploadComplete" />
			<asp:Image ID="imgFileLoading" runat="server" ImageUrl="~/App_Themes/Brown/img/loading_small.gif"
				Style="float: right; margin-top: -25px; margin-right: 10px;" />
			<div style="text-align: center; padding: 20px" >
<%--				<img id="imgFilePicture" style="margin: 20px; width: 160px; height: 120px;" />--%>
				<asp:Image ID="imgFilePicture" Width="160" Height="120" runat="server" />
			</div>
			
            <div class="ClearBoth"></div>
            <div class="ActionsRight">
                <asp:Button ID="btnSave" runat="server" 
                    Text="Save" onclick="btnSave_Click" TabIndex="5" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" CausesValidation="False" TabIndex="6" />
            </div>
        </div>

	</ContentTemplate>
</asp:UpdatePanel>