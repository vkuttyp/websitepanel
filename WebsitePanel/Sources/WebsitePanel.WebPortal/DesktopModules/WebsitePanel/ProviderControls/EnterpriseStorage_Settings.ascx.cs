// Copyright (c) 2012, Outercurve Foundation.
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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace WebsitePanel.Portal.ProviderControls
{
    public partial class EnterpriseStorage_Settings : WebsitePanelControlBase, IHostingServiceProviderSettings
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    chkEnableHardQuota.Enabled = ES.Services.EnterpriseStorage.CheckFileServicesInstallation(PanelRequest.ServiceId);
                    txtFolder.Enabled = chkEnableHardQuota.Enabled;
                    if (!chkEnableHardQuota.Enabled)
                        lblFileServiceInfo.Visible = true;
                }
                catch
                {
                }
            }
        }

        public void BindSettings(StringDictionary settings)
        {
            string path = string.Format("{0}:\\{1}", settings["LocationDrive"], settings["UsersHome"]);

            txtFolder.Text = path;
            txtDomain.Text = settings["UsersDomain"];
            chkEnableHardQuota.Checked = settings["EnableHardQuota"] == "true" ? true : false;
        }

        public void SaveSettings(StringDictionary settings)
        {
            var drive = System.IO.Path.GetPathRoot(txtFolder.Text);
            var folder = txtFolder.Text.Replace(drive, string.Empty);

            if (!string.IsNullOrEmpty(drive) && !string.IsNullOrEmpty(folder))
            {
                settings["LocationDrive"] = drive.Split(':')[0];
                settings["UsersHome"] = folder;
                settings["UsersDomain"] = txtDomain.Text;
                settings["EnableHardQuota"] = chkEnableHardQuota.Checked.ToString().ToLower();
            }
        }
    }
}