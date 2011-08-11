﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryCrudView.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.CategoryCrudView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="CategoryEditUC.ascx" tagname="CategoryEditUC" tagprefix="uc1" %>

<asp:UpdatePanel ID="UpdatePanelActions" runat="server">
    <ContentTemplate>
        <div id="Actions">
            <asp:ImageButton ID="BtnAdd" runat="server" ImageUrl="~/Img/new.png" 
                AlternateText="Add new" ToolTip="Add new item" CausesValidation="False" 
                TabIndex="11" />
                
            <div class="ActionsRight">
				<asp:Label ID="LblSlowWorkTime" runat="server" Text="Process Time (sec)" />
                <asp:TextBox ID="TxtSlowWorkTime" runat="server" MaxLength="2" Width="40px"></asp:TextBox>
                <asp:Button ID="BtnSlowWork" runat="server" Text="Run some slow process in background..." TabIndex="5" />
            </div>
        </div>

        <asp:Panel ID="panelEdit" runat="server" CssClass="PanelEditar" Style="display: none;">
        	<uc1:CategoryEditUC ID="CategoryEditUC1" runat="server" />
        </asp:Panel>
        
        <cc1:ModalPopupExtender ID="ModalPopupNew" runat="server"
            PopupControlID="PanelEdit" TargetControlID="BtnAdd" 
            BackgroundCssClass="ModalPopupBackground" BehaviorID="ModalPopupNew" />
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="updatePanelGrid" runat="server">
	<ContentTemplate>
        <asp:Panel ID="panelDataGrid" runat="server">
            <asp:GridView ID="DataGridCategories" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" Width="600px" onrowdeleting="DataGridCategories_RowDeleting" 
                onrowediting="DataGridCategories_RowEditing" ForeColor="#333333" 
                GridLines="None" AllowPaging="True" PageSize="6">
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnDeleteItem" runat="server" CausesValidation="False" 
                                CommandName="Delete" ImageUrl="~/Img/delete.png" AlternateText="Delete" ToolTip="Delete item" />
                            <cc1:ConfirmButtonExtender ID="BtnConfirmDelete" runat="server" TargetControlID="BtnDeleteItem" 
                                ConfirmText="Do you really want to delete the item?" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="50px" >
                    <ItemStyle Width="50px" />
					</asp:BoundField>
                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="BtnEditItem" runat="server" CausesValidation="False" 
                                Text='<%# Bind("CategoryName") %>' CommandName="Edit" ToolTip="Edit item"></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Description" HeaderText="Description" 
						ItemStyle-Width="200px" >
                    <ItemStyle Width="200px" />
					</asp:BoundField>
                    <asp:ImageField HeaderText="Picture" DataImageUrlFormatString="~/CategoryImageReadHandlerView.ashx?ID={0}" DataImageUrlField="ID" />
                </Columns>
                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
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