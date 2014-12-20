﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VpsDetailsPermissions.ascx.cs" Inherits="WebsitePanel.Portal.VPSForPC.VpsDetailsPermissions" %>
<%@ Register Src="../UserControls/SimpleMessageBox.ascx" TagName="SimpleMessageBox" TagPrefix="wsp" %>
<%@ Register Src="UserControls/ServerTabs.ascx" TagName="ServerTabs" TagPrefix="wsp" %>
<%@ Register Src="UserControls/Menu.ascx" TagName="Menu" TagPrefix="wsp" %>
<%@ Register Src="UserControls/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="wsp" %>
<%@ Register Src="UserControls/FormTitle.ascx" TagName="FormTitle" TagPrefix="wsp" %>

<div id="VpsContainer">
    <div class="Module">

	    <div class="Header">
		    <wsp:Breadcrumb id="breadcrumb" runat="server" />
	    </div>
    	
	    <div class="Left">
		    <wsp:Menu id="menu" runat="server" SelectedItem="" />
	    </div>
    	
	    <div class="Content">
		    <div class="Center">
			    <div class="Title">
				    <asp:Image ID="imgIcon" SkinID="Server48" runat="server" />
				    <wsp:FormTitle ID="locTitle" runat="server" meta:resourcekey="locTitle" Text="Permissions" />
			    </div>
			    <div class="FormBody">
			        <wsp:ServerTabs id="tabs" runat="server" SelectedTab="vps_permissions" />	
                    <wsp:SimpleMessageBox id="messageBox" runat="server" />
                    
                    <div class="FormButtonsBarClean">
                        <asp:CheckBox ID="chkOverride" runat="server" meta:resourcekey="chkOverride"
                                Text="Override space permissions" AutoPostBack="true" />
                    </div>
                    
		            <asp:GridView ID="gvVpsPermissions" runat="server" AutoGenerateColumns="False"
			            EmptyDataText="gvVpsPermissions" CssSelectorClass="NormalGridView">
			            <Columns>
				            <asp:BoundField HeaderText="columnUsername" DataField="Username" />
				            <asp:TemplateField HeaderText="columnChangeState" ItemStyle-HorizontalAlign="Center">
				                <ItemTemplate>
				                    <asp:CheckBox ID="chkChangeState" runat="server" />
				                </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText="columnChangeConfig" ItemStyle-HorizontalAlign="Center">
				                <ItemTemplate>
				                    <asp:CheckBox ID="chkChangeConfig" runat="server" />
				                </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText="columnManageSnapshots" ItemStyle-HorizontalAlign="Center">
				                <ItemTemplate>
				                    <asp:CheckBox ID="chkManageSnapshots" runat="server" />
				                </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText="columnDeleteVps" ItemStyle-HorizontalAlign="Center">
				                <ItemTemplate>
				                    <asp:CheckBox ID="chkDeleteVps" runat="server" />
				                </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText="columnReinstallVps" ItemStyle-HorizontalAlign="Center">
				                <ItemTemplate>
				                    <asp:CheckBox ID="chkReinstallVps" runat="server" />
				                </ItemTemplate>
				            </asp:TemplateField>
			            </Columns>
		            </asp:GridView>
		            <br />
                    <asp:Button ID="btnUpdateVpsPermissions" runat="server" meta:resourcekey="btnUpdateVdcPermissions"
                            CssClass="Button1" Text="Update" CausesValidation="false" />
                    <br />
				    
			    </div>
		    </div>
		    <div class="Right">
			    <asp:Localize ID="FormComments" runat="server" meta:resourcekey="HSFormComments"></asp:Localize>
		    </div>
	    </div>
    	
    </div>
</div>