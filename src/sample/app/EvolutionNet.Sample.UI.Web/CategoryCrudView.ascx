<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryCrudView.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.CategoryCrudView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="CategoryEditUC.ascx" tagname="CategoryEditUC" tagprefix="uc1" %>

<asp:UpdatePanel ID="updatePanelActions" runat="server">
    <ContentTemplate>
        <div id="Actions">
            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Img/new.png" 
                AlternateText="Add new" ToolTip="Add new item" CausesValidation="False" 
                TabIndex="11" />
        </div>

        <asp:Panel ID="panelEdit" runat="server" CssClass="PanelEditar" Style="display: none;">
        	<uc1:CategoryEditUC ID="CategoryEditUC1" runat="server" />
        </asp:Panel>
        
        <cc1:ModalPopupExtender ID="modalPopupNew" runat="server"
            PopupControlID="panelEdit" TargetControlID="btnAdd" 
            BackgroundCssClass="ModalPopupBackground" BehaviorID="modalPopupNew" />
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="updatePanelGrid" runat="server">
	<ContentTemplate>
        <asp:Panel ID="panelDataGrid" runat="server">
            <asp:GridView ID="dataGridView1" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" Width="600px" onrowdeleting="dataGridView1_RowDeleting" 
                onrowediting="dataGridView1_RowEditing" ForeColor="#333333" 
                GridLines="None">
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="buttonDelete" runat="server" CausesValidation="False" 
                                CommandName="Delete" ImageUrl="~/Img/delete.png" AlternateText="Delete" ToolTip="Delete item" />
                            <cc1:ConfirmButtonExtender ID="btnConfirmDelete" runat="server" TargetControlID="buttonDelete" 
                                ConfirmText="Do you really want to delete the item?" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="50px" />
                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" 
                                Text='<%# Bind("CategoryName") %>' CommandName="Edit" ToolTip="Edit item"></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="200px" />
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
<asp:UpdateProgress ID="updateProgress1" runat="server" 
    AssociatedUpdatePanelID="updatePanelActions">
    <ProgressTemplate>
        <div class="UpdateProgress" />
    </ProgressTemplate>
</asp:UpdateProgress>
--%>