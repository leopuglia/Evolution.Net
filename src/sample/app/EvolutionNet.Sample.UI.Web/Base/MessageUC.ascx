<%@ Control Language="C#" CodeBehind="MessageUC.ascx.cs" Inherits="EvolutionNet.Sample.UI.Web.Base.MessageUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelMessages" class="PanelMessages" runat="server" style="filter: alpha(opacity=0);display: none;">
            <div id="PanelMessagesCaption"><asp:Label ID="LabelCaption" runat="server" Text="Mensagem" /></div>
            <div id="PanelMessagesContent">
                <asp:Label ID="LabelMessage" runat="server" Text="" />
                <div class="ActionsRight">
                    <asp:Button ID="BtnOK" Text="OK" OnClientClick="return false;" runat="server" />
                </div>
            </div>
        </asp:Panel>

        <ajaxtoolkit:AnimationExtender ID="AnimationExtender1" runat="server" TargetControlID="BtnOK">
            <Animations>
                <OnClick>
                    <Sequence>
                        <FadeOut Duration=".3" AnimationTarget="PanelMessages" />
                        <StyleAction Attribute="display" Value="none" AnimationTarget="PanelMessages" />
                    </Sequence>
                </OnClick>
            </Animations>
        </ajaxtoolkit:AnimationExtender>
        
        <ajaxtoolkit:AnimationExtender ID="AnimationExtender2" runat="server" BehaviorID="messagesAE" TargetControlID="PanelMessages" Enabled="False">
            <Animations>
                <OnLoad>
                    <Sequence>
                        <StyleAction Attribute="display" Value="block" AnimationTarget="PanelMessages" />
                        <FadeIn Duration=".3" AnimationTarget="PanelMessages" />
                        <StyleAction Duration="5" />
                        <FadeOut Duration=".3" AnimationTarget="PanelMessages" />
                        <StyleAction Attribute="display" Value="none" AnimationTarget="PanelMessages" />
                    </Sequence>
                </OnLoad>
            </Animations>
        </ajaxtoolkit:AnimationExtender>
    </ContentTemplate>
</asp:UpdatePanel>

<ajaxtoolkit:UpdatePanelAnimationExtender ID="UPMessagesAnimationExtender" 
    runat="server" TargetControlID="UpdatePanelMessages">
    <Animations>
        <OnUpdated>
            <Sequence>
                <StyleAction Attribute="display" Value="block" AnimationTarget="PanelMessages" />
                <FadeIn Duration=".3" AnimationTarget="PanelMessages" />
                <StyleAction Duration="5" />
                <FadeOut Duration=".3" AnimationTarget="PanelMessages" />
                <StyleAction Attribute="display" Value="none" AnimationTarget="PanelMessages" />
            </Sequence>
        </OnUpdated>
    </Animations>
</ajaxtoolkit:UpdatePanelAnimationExtender>

