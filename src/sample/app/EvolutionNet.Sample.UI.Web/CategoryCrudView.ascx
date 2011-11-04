<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryCrudView.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.CategoryCrudView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="CategoryEditUC.ascx" tagname="CategoryEditUC" tagprefix="uc1" %>

<%--Test client script block--%>
<script type="text/javascript" language="javascript">
	function RunSlowWork() {
		CallServer(txtSlowWorkTime.value, "");
		ShowProgressPopup();
	}

	function ReceiveServerData(result) {
		//alert(result);
	}

	function ShowProgressPopup() {
		var modalPopup = $find('ModalPopupProgress');
		modalPopup.show();
	}
</script>

<asp:UpdatePanel ID="UpdatePanelActions" runat="server">
	<ContentTemplate>
		<div id="Actions">
			<div class="FloatRight">
				<asp:Label ID="LblSlowWorkTime" runat="server" Text="Process Time (sec)" />
				<asp:TextBox ID="TxtSlowWorkTime" runat="server" MaxLength="2" Width="25px" Text="5" />
				<%--<input id="TxtSlowWorkTime" type="text" value="5" />--%>
				<asp:Button ID="BtnSlowWork" runat="server" 
					Text="Run some slow process in background..." TabIndex="5" 
					onclick="BtnSlowWork_Click" OnClientClick="/*ShowProgressPopup();*/RunSlowWork(); return false;" />
			</div>
			
			<asp:ImageButton ID="BtnAdd" runat="server" ImageUrl="~/Img/new.png" 
				AlternateText="Add new" ToolTip="Add new item" CausesValidation="False" 
				TabIndex="11" />
				
		</div>

		<asp:Panel ID="PanelPopup" runat="server" Style="display: none;">
			<uc1:CategoryEditUC ID="CategoryEditUC1" runat="server" />
		</asp:Panel>
		
		<ajaxtoolkit:ModalPopupExtender ID="ModalPopupNew" runat="server"
			PopupControlID="PanelPopup" TargetControlID="BtnAdd" 
			BackgroundCssClass="ModalPopupBackground" BehaviorID="ModalPopupNew" />
	</ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
	<ContentTemplate>
		<asp:Panel ID="PanelDataGrid" runat="server">
			<asp:GridView ID="DataGridCategories" runat="server" AllowSorting="True" 
					AutoGenerateColumns="False" CellPadding="4" Width="100%"
					GridLines="None" AllowPaging="True" PageSize="6" 
					onrowdeleting="DataGridCategories_RowDeleting" 
					onrowediting="DataGridCategories_RowEditing" 
					onpageindexchanging="DataGridCategories_PageIndexChanging" 
					onsorting="DataGridCategories_Sorting">
				<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
				<RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
				<FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
				<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
				<AlternatingRowStyle BackColor="LightGray" />
				<Columns>
					<asp:TemplateField ShowHeader="False" >
						<ItemStyle Width="10px" />
						<ItemTemplate>
							<asp:ImageButton ID="BtnDeleteItem" runat="server" CausesValidation="False" 
								CommandName="Delete" ImageUrl="~/Img/delete.png" AlternateText="Delete" ToolTip="Delete item" />
							<ajaxtoolkit:ConfirmButtonExtender ID="BtnConfirmDelete" runat="server" TargetControlID="BtnDeleteItem" 
								ConfirmText="Do you really want to delete the item?" />
						</ItemTemplate>
					</asp:TemplateField>
					
					<asp:TemplateField ShowHeader="False" >
						<ItemStyle Width="10px" />
						<ItemTemplate>
							<asp:ImageButton ID="BtnEditItem" runat="server" CausesValidation="False" 
								CommandName="Edit" ImageUrl="~/Img/edit.png" AlternateText="Edit" ToolTip="Edit item" />
						</ItemTemplate>
					</asp:TemplateField>
					
					<asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
						<ItemStyle Width="30px" />
					</asp:BoundField>
					
					<asp:TemplateField HeaderText="Category Name" SortExpression="CategoryName">
						<ItemStyle Width="120px" />
						<ItemTemplate>
							<asp:LinkButton ID="BtnEditItemLink" runat="server" CausesValidation="False" 
								Text="<%# Bind('CategoryName') %>" CommandName="Edit" ToolTip="Edit item"></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
					
					<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" >
					</asp:BoundField>
					
					<asp:ImageField HeaderText="Picture" DataImageUrlField="ID"
						DataImageUrlFormatString="~/CategoryImageReadHandlerView.ashx?ID={0}" >
						<ItemStyle Width="160px" />
					</asp:ImageField>
					
				</Columns>
			</asp:GridView>
		</asp:Panel>
	</ContentTemplate>
</asp:UpdatePanel>

<%--
<asp:UpdateProgress ID="UpdateProgress1" runat="server" 
	AssociatedUpdatePanelID="UpdatePanelActions">
	<ProgressTemplate>
		<div class="UpdateProgress" />
	</ProgressTemplate>
</asp:UpdateProgress>
--%>