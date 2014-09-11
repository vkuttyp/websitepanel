// Copyright (c) 2014, Outercurve Foundation.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
// - Redistributions of source code must  retain  the  above copyright notice, this
//   list of conditions and the following disclaimer.
//
// - Redistributions in binary form  must  reproduce the  above  copyright  notice,
//   this list of conditions  and  the  following  disclaimer in  the documentation
//   and/or other materials provided with the distribution.
//
// - Neither  the  name  of  the  Outercurve Foundation  nor   the   names  of  its
//   contributors may be used to endorse or  promote  products  derived  from  this
//   software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,  BUT  NOT  LIMITED TO, THE IMPLIED
// WARRANTIES  OF  MERCHANTABILITY   AND  FITNESS  FOR  A  PARTICULAR  PURPOSE  ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL,  SPECIAL,  EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO,  PROCUREMENT  OF  SUBSTITUTE  GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)  HOWEVER  CAUSED AND ON
// ANY  THEORY  OF  LIABILITY,  WHETHER  IN  CONTRACT,  STRICT  LIABILITY,  OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE)  ARISING  IN  ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebsitePanel.EnterpriseServer;
using WebsitePanel.EnterpriseServer.Base.HostedSolution;
using WebsitePanel.Providers.HostedSolution;
using WebsitePanel.Providers.ResultObjects;

namespace WebsitePanel.Portal.HostedSolution
{
    public partial class UserGeneralSettings : WebsitePanelModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindServiceLevels();

                BindSettings();

                MailboxTabsId.Visible = (PanelRequest.Context == "Mailbox");
                UserTabsId.Visible = (PanelRequest.Context == "User");
            }
        }

        private void BindSettings()
        {
            try
            {
                password.SetPackagePolicy(PanelSecurity.PackageId, UserSettings.EXCHANGE_POLICY, "MailboxPasswordPolicy");
                PasswordPolicyResult passwordPolicy = ES.Services.Organizations.GetPasswordPolicy(PanelRequest.ItemID);
                if (passwordPolicy.IsSuccess)
                {
                    password.MinimumLength = passwordPolicy.Value.MinLength;
                    if (passwordPolicy.Value.IsComplexityEnable)
                    {
                        password.MinimumNumbers = 1;
                        password.MinimumSymbols = 1;
                        password.MinimumUppercase = 1;
                    }
                }

                // get settings
                OrganizationUser user = ES.Services.Organizations.GetUserGeneralSettings(PanelRequest.ItemID,
                    PanelRequest.AccountID);

                litDisplayName.Text = PortalAntiXSS.Encode(user.DisplayName);

                lblUserDomainName.Text = user.DomainUserName;

                // bind form
                txtDisplayName.Text = user.DisplayName;

                chkDisable.Checked = user.Disabled;

                txtFirstName.Text = user.FirstName;
                txtInitials.Text = user.Initials;
                txtLastName.Text = user.LastName;

                if (user.LevelId > 0 && secServiceLevels.Visible)
                {
                    ServiceLevel serviceLevel = ES.Services.Organizations.GetSupportServiceLevel(user.LevelId);

                    if (ddlServiceLevels.Items.FindByValue(serviceLevel.LevelId.ToString()) == null)
                        ddlServiceLevels.Items.Add(new ListItem(serviceLevel.LevelName, serviceLevel.LevelId.ToString()));

                    ddlServiceLevels.Items.FindByValue(string.Empty).Selected = false;
                    ddlServiceLevels.Items.FindByValue(serviceLevel.LevelId.ToString()).Selected = true; 
                }
                chkVIP.Checked = user.IsVIP && secServiceLevels.Visible;

                txtJobTitle.Text = user.JobTitle;
                txtCompany.Text = user.Company;
                txtDepartment.Text = user.Department;
                txtOffice.Text = user.Office;
                manager.SetAccount(user.Manager);

                txtBusinessPhone.Text = user.BusinessPhone;
                txtFax.Text = user.Fax;
                txtHomePhone.Text = user.HomePhone;
                txtMobilePhone.Text = user.MobilePhone;
                txtPager.Text = user.Pager;
                txtWebPage.Text = user.WebPage;

                txtAddress.Text = user.Address;
                txtCity.Text = user.City;
                txtState.Text = user.State;
                txtZip.Text = user.Zip;
                country.Country = user.Country;

                txtNotes.Text = user.Notes;
                txtExternalEmailAddress.Text = user.ExternalEmail;

                txtExternalEmailAddress.Enabled = user.AccountType == ExchangeAccountType.User;
                lblUserDomainName.Text = user.DomainUserName;

                txtSubscriberNumber.Text = user.SubscriberNumber;
                lblUserPrincipalName.Text = user.UserPrincipalName;

                PackageContext cntx = PackagesHelper.GetCachedPackageContext(PanelSecurity.PackageId);
                if (cntx.Quotas.ContainsKey(Quotas.EXCHANGE2007_ISCONSUMER))
                {
                    if (cntx.Quotas[Quotas.EXCHANGE2007_ISCONSUMER].QuotaAllocatedValue != 1)
                    {
                        locSubscriberNumber.Visible = false;
                        txtSubscriberNumber.Visible = false;
                    }
                }


                if (cntx.Quotas.ContainsKey(Quotas.ORGANIZATION_ALLOWCHANGEUPN))
                {
                    if (cntx.Quotas[Quotas.ORGANIZATION_ALLOWCHANGEUPN].QuotaAllocatedValue != 1)
                    {
                        lblUserPrincipalName.Visible = true;
                        upn.Visible = false;
                        ddlEmailAddresses.Visible = false;
                        btnSetUserPrincipalName.Visible = false;
                        chkInherit.Visible = false;
                    }
                    else
                    {
                        lblUserPrincipalName.Visible = false;
                        upn.Visible = false;
                        ddlEmailAddresses.Visible = false;
                        btnSetUserPrincipalName.Visible = true;
                        chkInherit.Visible = true;
                        if (user.AccountType == ExchangeAccountType.Mailbox)
                        {
                            ddlEmailAddresses.Visible = true;
                            WebsitePanel.EnterpriseServer.ExchangeEmailAddress[] emails = ES.Services.ExchangeServer.GetMailboxEmailAddresses(PanelRequest.ItemID, PanelRequest.AccountID);

                            foreach (WebsitePanel.EnterpriseServer.ExchangeEmailAddress mail in emails)
                            {
                                ListItem li = new ListItem();
                                li.Text = mail.EmailAddress;
                                li.Value = mail.EmailAddress;
                                li.Selected = mail.IsPrimary;
                                ddlEmailAddresses.Items.Add(li);
                            }

                            foreach (ListItem li in ddlEmailAddresses.Items)
                            {
                                if (li.Value == user.UserPrincipalName)
                                {
                                    ddlEmailAddresses.ClearSelection();
                                    li.Selected = true;
                                    break;
                                }
                            }

                        }
                        else
                        {
                            upn.Visible = true;
                            if (!string.IsNullOrEmpty(user.UserPrincipalName))
                            {
                                string[] Tmp = user.UserPrincipalName.Split('@');
                                upn.AccountName = Tmp[0];

                                if (Tmp.Length > 1)
                                {
                                    upn.DomainName = Tmp[1];
                                }
                            }
                        }

                    }
                }

                if (user.Locked)
                    chkLocked.Enabled = true;
                else
                    chkLocked.Enabled = false;

                chkLocked.Checked = user.Locked;

                password.ValidationEnabled = true;
                password.Password = string.Empty;
            }
            catch (Exception ex)
            {
                messageBox.ShowErrorMessage("ORGANIZATION_GET_USER_SETTINGS", ex);
            }
        }

        private void BindServiceLevels()
        {
            PackageContext cntx = PackagesHelper.GetCachedPackageContext(PanelSecurity.PackageId);

            if (cntx.Groups.ContainsKey(ResourceGroups.ServiceLevels))
            {
                List<ServiceLevel> enabledServiceLevels = new List<ServiceLevel>();

                foreach (var quota in cntx.Quotas.Where(x => x.Key.Contains(Quotas.SERVICE_LEVELS)))
                {
                    foreach (var serviceLevel in ES.Services.Organizations.GetSupportServiceLevels())
                    {
                        if (quota.Key.Replace(Quotas.SERVICE_LEVELS, "") == serviceLevel.LevelName && CheckServiceLevelQuota(quota.Value, serviceLevel.LevelId))
                        {
                            enabledServiceLevels.Add(serviceLevel);
                        }
                    }
                }

                ddlServiceLevels.DataSource = enabledServiceLevels;
                ddlServiceLevels.DataTextField = "LevelName";
                ddlServiceLevels.DataValueField = "LevelId";
                ddlServiceLevels.DataBind();

                ddlServiceLevels.Items.Insert(0, new ListItem("<Select Service Level>", string.Empty));
                ddlServiceLevels.Items.FindByValue(string.Empty).Selected = true;

                secServiceLevels.Visible = true;
            }
            else { secServiceLevels.Visible = false; }

        }

        private bool CheckServiceLevelQuota(QuotaValueInfo quota, int levelID)
        {
            quota.QuotaUsedValue = ES.Services.Organizations.SearchAccounts(PanelRequest.ItemID, "", "", "", true).Where(x => x.LevelId == levelID).Count();

            if (quota.QuotaAllocatedValue != -1)
            {
                return quota.QuotaAllocatedValue > quota.QuotaUsedValue;
            }

            return true;
        }

        private void SaveSettings()
        {
            if (!Page.IsValid)
                return;

            try
            {
                int result = ES.Services.Organizations.SetUserGeneralSettings(
                    PanelRequest.ItemID, PanelRequest.AccountID,
                    txtDisplayName.Text,
                    string.Empty,
                    false,
                    chkDisable.Checked,
                    chkLocked.Checked,

                    txtFirstName.Text,
                    txtInitials.Text,
                    txtLastName.Text,

                    txtAddress.Text,
                    txtCity.Text,
                    txtState.Text,
                    txtZip.Text,
                    country.Country,

                    txtJobTitle.Text,
                    txtCompany.Text,
                    txtDepartment.Text,
                    txtOffice.Text,
                    manager.GetAccount(),

                    txtBusinessPhone.Text,
                    txtFax.Text,
                    txtHomePhone.Text,
                    txtMobilePhone.Text,
                    txtPager.Text,
                    txtWebPage.Text,
                    txtNotes.Text,
                    txtExternalEmailAddress.Text,
                    txtSubscriberNumber.Text,
                    string.IsNullOrEmpty(ddlServiceLevels.SelectedValue) ? 0 : int.Parse(ddlServiceLevels.SelectedValue),
                    chkVIP.Checked);

                if (result < 0)
                {
                    messageBox.ShowResultMessage(result);
                    return;
                }

                // update title
                litDisplayName.Text = txtDisplayName.Text;
                if (!chkLocked.Checked)
                    chkLocked.Enabled = false;

                messageBox.ShowSuccessMessage("ORGANIZATION_UPDATE_USER_SETTINGS");
            }
            catch (Exception ex)
            {
                messageBox.ShowErrorMessage("ORGANIZATION_UPDATE_USER_SETTINGS", ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        protected void btnSetUserPrincipalName_Click(object sender, EventArgs e)
        {

            string userPrincipalName = string.Empty;

            if (upn.Visible)
                userPrincipalName = upn.Email;
            else
                if (ddlEmailAddresses.Visible)
                    userPrincipalName = (string)ddlEmailAddresses.SelectedValue;

            if (string.IsNullOrEmpty(userPrincipalName)) return;

            try
            {
                int result = ES.Services.Organizations.SetUserPrincipalName(
                    PanelRequest.ItemID, PanelRequest.AccountID,
                    userPrincipalName.ToLower(),
                    chkInherit.Checked);

                if (result < 0)
                {
                    messageBox.ShowResultMessage(result);
                    return;
                }

                messageBox.ShowSuccessMessage("ORGANIZATION_SET_USER_USERPRINCIPALNAME");
            }
            catch (Exception ex)
            {
                messageBox.ShowErrorMessage("ORGANIZATION_SET_USER_USERPRINCIPALNAME", ex);
            }
        }

        protected void btnSetUserPassword_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
                return;

            try
            {
                int result = ES.Services.Organizations.SetUserPassword(
                    PanelRequest.ItemID, PanelRequest.AccountID,
                    password.Password);

                if (result < 0)
                {
                    messageBox.ShowResultMessage(result);
                    return;
                }

                messageBox.ShowSuccessMessage("ORGANIZATION_SET_USER_PASSWORD");
            }
            catch (Exception ex)
            {
                messageBox.ShowErrorMessage("ORGANIZATION_SET_USER_PASSWORD", ex);
            }


        }

    }
}