<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryEditUC.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.CategoryEditUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:UpdatePanel ID="UpdatePanelEdit" runat="server">
	<ContentTemplate>
	
        <div id="PanelCaption"><asp:Label ID="LblCaption" runat="server" Text="Category Data" /></div>
        <div id="PanelDados">
            <asp:Label ID="LblCategoryName" runat="server" Text="Category Name"></asp:Label>
            <asp:TextBox ID="TxtCategoryName" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
<%--
            <asp:RequiredFieldValidator ID="RfvNome" runat="server" ControlToValidate="TxtName"
                ErrorMessage="* campo requerido" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
--%>
            
            <asp:Label ID="LblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="TxtDescription" runat="server" Width="390px" Rows="3" 
                TextMode="MultiLine" TabIndex="2"></asp:TextBox>
                
            <asp:Label ID="LblPicture" runat="server" Text="Picture"></asp:Label>
			<cc1:AsyncFileUpload ID="filePicture" runat="server" ThrobberID="ImgFileLoading"
				onuploadedcomplete="FilePicture_UploadedComplete" OnClientUploadComplete="UploadComplete" />
			<asp:Image ID="ImgFileLoading" runat="server" ImageUrl="~/App_Themes/Brown/img/loading_small.gif"
				Style="float: right; margin-top: -25px; margin-right: 10px;" />
			<div style="text-align: center; padding: 20px" >
				<asp:Image ID="ImgFilePicture" Width="160" Height="120" runat="server" />
			</div>
			
            <div class="ClearBoth"></div>
            <div class="ActionsRight">
                <asp:Button ID="BtnSave" runat="server" 
                    Text="Save" onclick="BtnSave_Click" TabIndex="5" />
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
                    onclick="BtnCancel_Click" CausesValidation="False" TabIndex="6" />
            </div>
        </div>

	</ContentTemplate>
</asp:UpdatePanel>