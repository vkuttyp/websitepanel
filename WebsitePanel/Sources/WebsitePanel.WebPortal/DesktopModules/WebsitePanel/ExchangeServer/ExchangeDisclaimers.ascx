<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExchangeDisclaimers.ascx.cs" Inherits="WebsitePanel.Portal.ExchangeServer.ExchangeDisclaimers" %>
<%@ Register Src="../UserControls/SimpleMessageBox.ascx" TagName="SimpleMessageBox" TagPrefix="wsp" %>
<%@ Register Src="../UserControls/QuotaViewer.ascx" TagName="QuotaViewer" TagPrefix="wsp" %>
<%@ Register Src="../UserControls/EnableAsyncTasksSupport.ascx" TagName="EnableAsyncTasksSupport" TagPrefix="wsp" %>

<wsp:EnableAsyncTasksSupport id="asyncTasks" runat="server"/>

<div id="ExchangeContainer">
	<div class="Module">
		<div class="Left">
		</div>
		<div class="Content">
			<div class="Center">
				<div class="Title">
					<asp:Image ID="Image1" SkinID="ExchangeList48" runat="server" />
					<asp:Localize ID="locTitle" runat="server" meta:resourcekey="locTitle" Text="Lists"></asp:Localize>
				</div>
				
				<div class="FormBody">
				    <wsp:SimpleMessageBox id="messageBox" runat="server" />
                    <div class="FormButtonsBarClean">
                        <div class="FormButtonsBarCleanLeft">
                            <asp:Button ID="btnCreateList" runat="server" meta:resourcekey="btnCreateList"
                            Text="Create New Distribution List" CssClass="Button1" OnClick="btnCreateList_Click" />
                        </div>
                        <div class="FormButtonsBarCleanRight">
                            <%-- 
                            <asp:Panel ID="SearchPanel" runat="server" DefaultButton="cmdSearch">
                            <asp:Localize ID="locSearch" runat="server" meta:resourcekey="locSearch" Visible="false"></asp:Localize>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True"    
                                       onselectedindexchanged="ddlPageSize_SelectedIndexChanged">   
                                       <asp:ListItem>10</asp:ListItem>   
                                       <asp:ListItem Selected="True">20</asp:ListItem>   
                                       <asp:ListItem>50</asp:ListItem>   
                                       <asp:ListItem>100</asp:ListItem>   
                                </asp:DropDownList>  

                                <asp:DropDownList ID="ddlSearchColumn" runat="server" CssClass="NormalTextBox">
                                    <asp:ListItem Value="DisplayName" meta:resourcekey="ddlSearchColumnDisplayName">DisplayName</asp:ListItem>
                                </asp:DropDownList><asp:TextBox ID="txtSearchValue" runat="server" CssClass="NormalTextBox" Width="100"></asp:TextBox><asp:ImageButton ID="cmdSearch" Runat="server" meta:resourcekey="cmdSearch" SkinID="SearchButton"
		                            CausesValidation="false"/>
                            </asp:Panel>
                            --%>
                        </div>
                    </div>

				    <asp:GridView ID="gvLists" runat="server" AutoGenerateColumns="False" EnableViewState="true"
					    Width="100%" EmptyDataText="gvLists" CssSelectorClass="NormalGridView"
					    OnRowCommand="gvLists_RowCommand" AllowPaging="True" AllowSorting="True"
					    PageSize="20">
					    <Columns>
						    <asp:TemplateField HeaderText="gvListsDisplayName" SortExpression="DisplayName">
							    <ItemStyle Width="80%"></ItemStyle>
							    <ItemTemplate>
								    <asp:hyperlink id="lnk1" runat="server"
									    NavigateUrl='<%# GetListEditUrl(Eval("ExchangeDisclaimerId").ToString()) %>'>
									    <%# Eval("DisclaimerName")%>
								    </asp:hyperlink>
							    </ItemTemplate>
						    </asp:TemplateField>
						    <asp:TemplateField>
							    <ItemTemplate>
								    <asp:ImageButton ID="cmdDelete" runat="server" Text="Delete" SkinID="ExchangeDelete"
									    CommandName="DeleteItem" CommandArgument='<%# Eval("ExchangeDisclaimerId") %>'
									    meta:resourcekey="cmdDelete" OnClientClick="return confirm('Remove this item?');"></asp:ImageButton>
							    </ItemTemplate>
						    </asp:TemplateField>
					    </Columns>
				    </asp:GridView>
				    <br />
				    <asp:Localize ID="locQuota" runat="server" meta:resourcekey="locQuota" Text="Total Distribution Lists Created:"></asp:Localize>
				    &nbsp;&nbsp;&nbsp;
				    <wsp:QuotaViewer ID="listsQuota" runat="server" QuotaTypeId="2" />
				    
				    
				</div>
			</div>
		</div>
	</div>
</div>