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

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.42.
// 
namespace WebsitePanel.EnterpriseServer
{
	using System.Xml.Serialization;
	using System.Web.Services;
	using System.ComponentModel;
	using System.Web.Services.Protocols;
	using System;
	using System.Diagnostics;


	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(Name = "esAuthenticationSoap", Namespace = "http://smbsaas/websitepanel/enterpriseserver")]
	public partial class esAuthentication : Microsoft.Web.Services3.WebServicesClientProtocol
	{

		private System.Threading.SendOrPostCallback AuthenticateUserOperationCompleted;

		private System.Threading.SendOrPostCallback GetUserByUsernamePasswordOperationCompleted;

		private System.Threading.SendOrPostCallback ChangeUserPasswordByUsernameOperationCompleted;

		private System.Threading.SendOrPostCallback SendPasswordReminderOperationCompleted;

		private System.Threading.SendOrPostCallback GetSystemSetupModeOperationCompleted;

		private System.Threading.SendOrPostCallback SetupControlPanelAccountsOperationCompleted;

		/// <remarks/>
		public esAuthentication()
		{
			this.Url = "http://localhost:9002/esAuthentication.asmx";
		}

		/// <remarks/>
		public event AuthenticateUserCompletedEventHandler AuthenticateUserCompleted;

		/// <remarks/>
		public event GetUserByUsernamePasswordCompletedEventHandler GetUserByUsernamePasswordCompleted;

		/// <remarks/>
		public event ChangeUserPasswordByUsernameCompletedEventHandler ChangeUserPasswordByUsernameCompleted;

		/// <remarks/>
		public event SendPasswordReminderCompletedEventHandler SendPasswordReminderCompleted;

		/// <remarks/>
		public event GetSystemSetupModeCompletedEventHandler GetSystemSetupModeCompleted;

		/// <remarks/>
		public event SetupControlPanelAccountsCompletedEventHandler SetupControlPanelAccountsCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://smbsaas/websitepanel/enterpriseserver/AuthenticateUser", RequestNamespace = "http://smbsaas/websitepanel/enterpriseserver", ResponseNamespace = "http://smbsaas/websitepanel/enterpriseserver", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public int AuthenticateUser(string username, string password, string ip)
		{
			object[] results = this.Invoke("AuthenticateUser", new object[] {
                        username,
                        password,
                        ip});
			return ((int)(results[0]));
		}

		/// <remarks/>
		public System.IAsyncResult BeginAuthenticateUser(string username, string password, string ip, System.AsyncCallback callback, object asyncState)
		{
			return this.BeginInvoke("AuthenticateUser", new object[] {
                        username,
                        password,
                        ip}, callback, asyncState);
		}

		/// <remarks/>
		public int EndAuthenticateUser(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((int)(results[0]));
		}

		/// <remarks/>
		public void AuthenticateUserAsync(string username, string password, string ip)
		{
			this.AuthenticateUserAsync(username, password, ip, null);
		}

		/// <remarks/>
		public void AuthenticateUserAsync(string username, string password, string ip, object userState)
		{
			if ((this.AuthenticateUserOperationCompleted == null))
			{
				this.AuthenticateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAuthenticateUserOperationCompleted);
			}
			this.InvokeAsync("AuthenticateUser", new object[] {
                        username,
                        password,
                        ip}, this.AuthenticateUserOperationCompleted, userState);
		}

		private void OnAuthenticateUserOperationCompleted(object arg)
		{
			if ((this.AuthenticateUserCompleted != null))
			{
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.AuthenticateUserCompleted(this, new AuthenticateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://smbsaas/websitepanel/enterpriseserver/GetUserByUsernamePassword", RequestNamespace = "http://smbsaas/websitepanel/enterpriseserver", ResponseNamespace = "http://smbsaas/websitepanel/enterpriseserver", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public UserInfo GetUserByUsernamePassword(string username, string password, string ip)
		{
			object[] results = this.Invoke("GetUserByUsernamePassword", new object[] {
                        username,
                        password,
                        ip});
			return ((UserInfo)(results[0]));
		}

		/// <remarks/>
		public System.IAsyncResult BeginGetUserByUsernamePassword(string username, string password, string ip, System.AsyncCallback callback, object asyncState)
		{
			return this.BeginInvoke("GetUserByUsernamePassword", new object[] {
                        username,
                        password,
                        ip}, callback, asyncState);
		}

		/// <remarks/>
		public UserInfo EndGetUserByUsernamePassword(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((UserInfo)(results[0]));
		}

		/// <remarks/>
		public void GetUserByUsernamePasswordAsync(string username, string password, string ip)
		{
			this.GetUserByUsernamePasswordAsync(username, password, ip, null);
		}

		/// <remarks/>
		public void GetUserByUsernamePasswordAsync(string username, string password, string ip, object userState)
		{
			if ((this.GetUserByUsernamePasswordOperationCompleted == null))
			{
				this.GetUserByUsernamePasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserByUsernamePasswordOperationCompleted);
			}
			this.InvokeAsync("GetUserByUsernamePassword", new object[] {
                        username,
                        password,
                        ip}, this.GetUserByUsernamePasswordOperationCompleted, userState);
		}

		private void OnGetUserByUsernamePasswordOperationCompleted(object arg)
		{
			if ((this.GetUserByUsernamePasswordCompleted != null))
			{
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.GetUserByUsernamePasswordCompleted(this, new GetUserByUsernamePasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://smbsaas/websitepanel/enterpriseserver/ChangeUserPasswordByUsername", RequestNamespace = "http://smbsaas/websitepanel/enterpriseserver", ResponseNamespace = "http://smbsaas/websitepanel/enterpriseserver", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public int ChangeUserPasswordByUsername(string username, string oldPassword, string newPassword, string ip)
		{
			object[] results = this.Invoke("ChangeUserPasswordByUsername", new object[] {
                        username,
                        oldPassword,
                        newPassword,
                        ip});
			return ((int)(results[0]));
		}

		/// <remarks/>
		public System.IAsyncResult BeginChangeUserPasswordByUsername(string username, string oldPassword, string newPassword, string ip, System.AsyncCallback callback, object asyncState)
		{
			return this.BeginInvoke("ChangeUserPasswordByUsername", new object[] {
                        username,
                        oldPassword,
                        newPassword,
                        ip}, callback, asyncState);
		}

		/// <remarks/>
		public int EndChangeUserPasswordByUsername(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((int)(results[0]));
		}

		/// <remarks/>
		public void ChangeUserPasswordByUsernameAsync(string username, string oldPassword, string newPassword, string ip)
		{
			this.ChangeUserPasswordByUsernameAsync(username, oldPassword, newPassword, ip, null);
		}

		/// <remarks/>
		public void ChangeUserPasswordByUsernameAsync(string username, string oldPassword, string newPassword, string ip, object userState)
		{
			if ((this.ChangeUserPasswordByUsernameOperationCompleted == null))
			{
				this.ChangeUserPasswordByUsernameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangeUserPasswordByUsernameOperationCompleted);
			}
			this.InvokeAsync("ChangeUserPasswordByUsername", new object[] {
                        username,
                        oldPassword,
                        newPassword,
                        ip}, this.ChangeUserPasswordByUsernameOperationCompleted, userState);
		}

		private void OnChangeUserPasswordByUsernameOperationCompleted(object arg)
		{
			if ((this.ChangeUserPasswordByUsernameCompleted != null))
			{
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.ChangeUserPasswordByUsernameCompleted(this, new ChangeUserPasswordByUsernameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://smbsaas/websitepanel/enterpriseserver/SendPasswordReminder", RequestNamespace = "http://smbsaas/websitepanel/enterpriseserver", ResponseNamespace = "http://smbsaas/websitepanel/enterpriseserver", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public int SendPasswordReminder(string username, string ip)
		{
			object[] results = this.Invoke("SendPasswordReminder", new object[] {
                        username,
                        ip});
			return ((int)(results[0]));
		}

		/// <remarks/>
		public System.IAsyncResult BeginSendPasswordReminder(string username, string ip, System.AsyncCallback callback, object asyncState)
		{
			return this.BeginInvoke("SendPasswordReminder", new object[] {
                        username,
                        ip}, callback, asyncState);
		}

		/// <remarks/>
		public int EndSendPasswordReminder(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((int)(results[0]));
		}

		/// <remarks/>
		public void SendPasswordReminderAsync(string username, string ip)
		{
			this.SendPasswordReminderAsync(username, ip, null);
		}

		/// <remarks/>
		public void SendPasswordReminderAsync(string username, string ip, object userState)
		{
			if ((this.SendPasswordReminderOperationCompleted == null))
			{
				this.SendPasswordReminderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendPasswordReminderOperationCompleted);
			}
			this.InvokeAsync("SendPasswordReminder", new object[] {
                        username,
                        ip}, this.SendPasswordReminderOperationCompleted, userState);
		}

		private void OnSendPasswordReminderOperationCompleted(object arg)
		{
			if ((this.SendPasswordReminderCompleted != null))
			{
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.SendPasswordReminderCompleted(this, new SendPasswordReminderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://smbsaas/websitepanel/enterpriseserver/GetSystemSetupMode", RequestNamespace = "http://smbsaas/websitepanel/enterpriseserver", ResponseNamespace = "http://smbsaas/websitepanel/enterpriseserver", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public bool GetSystemSetupMode()
		{
			object[] results = this.Invoke("GetSystemSetupMode", new object[0]);
			return ((bool)(results[0]));
		}

		/// <remarks/>
		public System.IAsyncResult BeginGetSystemSetupMode(System.AsyncCallback callback, object asyncState)
		{
			return this.BeginInvoke("GetSystemSetupMode", new object[0], callback, asyncState);
		}

		/// <remarks/>
		public bool EndGetSystemSetupMode(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((bool)(results[0]));
		}

		/// <remarks/>
		public void GetSystemSetupModeAsync()
		{
			this.GetSystemSetupModeAsync(null);
		}

		/// <remarks/>
		public void GetSystemSetupModeAsync(object userState)
		{
			if ((this.GetSystemSetupModeOperationCompleted == null))
			{
				this.GetSystemSetupModeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSystemSetupModeOperationCompleted);
			}
			this.InvokeAsync("GetSystemSetupMode", new object[0], this.GetSystemSetupModeOperationCompleted, userState);
		}

		private void OnGetSystemSetupModeOperationCompleted(object arg)
		{
			if ((this.GetSystemSetupModeCompleted != null))
			{
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.GetSystemSetupModeCompleted(this, new GetSystemSetupModeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://smbsaas/websitepanel/enterpriseserver/SetupControlPanelAccounts", RequestNamespace = "http://smbsaas/websitepanel/enterpriseserver", ResponseNamespace = "http://smbsaas/websitepanel/enterpriseserver", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public int SetupControlPanelAccounts(string passwordA, string passwordB, string ip)
		{
			object[] results = this.Invoke("SetupControlPanelAccounts", new object[] {
                        passwordA,
                        passwordB,
                        ip});
			return ((int)(results[0]));
		}

		/// <remarks/>
		public System.IAsyncResult BeginSetupControlPanelAccounts(string passwordA, string passwordB, string ip, System.AsyncCallback callback, object asyncState)
		{
			return this.BeginInvoke("SetupControlPanelAccounts", new object[] {
                        passwordA,
                        passwordB,
                        ip}, callback, asyncState);
		}

		/// <remarks/>
		public int EndSetupControlPanelAccounts(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((int)(results[0]));
		}

		/// <remarks/>
		public void SetupControlPanelAccountsAsync(string passwordA, string passwordB, string ip)
		{
			this.SetupControlPanelAccountsAsync(passwordA, passwordB, ip, null);
		}

		/// <remarks/>
		public void SetupControlPanelAccountsAsync(string passwordA, string passwordB, string ip, object userState)
		{
			if ((this.SetupControlPanelAccountsOperationCompleted == null))
			{
				this.SetupControlPanelAccountsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetupControlPanelAccountsOperationCompleted);
			}
			this.InvokeAsync("SetupControlPanelAccounts", new object[] {
                        passwordA,
                        passwordB,
                        ip}, this.SetupControlPanelAccountsOperationCompleted, userState);
		}

		private void OnSetupControlPanelAccountsOperationCompleted(object arg)
		{
			if ((this.SetupControlPanelAccountsCompleted != null))
			{
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.SetupControlPanelAccountsCompleted(this, new SetupControlPanelAccountsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
			}
		}

		/// <remarks/>
		public new void CancelAsync(object userState)
		{
			base.CancelAsync(userState);
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	public delegate void AuthenticateUserCompletedEventHandler(object sender, AuthenticateUserCompletedEventArgs e);

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class AuthenticateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{

		private object[] results;

		internal AuthenticateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
			base(exception, cancelled, userState)
		{
			this.results = results;
		}

		/// <remarks/>
		public int Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((int)(this.results[0]));
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	public delegate void GetUserByUsernamePasswordCompletedEventHandler(object sender, GetUserByUsernamePasswordCompletedEventArgs e);

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class GetUserByUsernamePasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{

		private object[] results;

		internal GetUserByUsernamePasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
			base(exception, cancelled, userState)
		{
			this.results = results;
		}

		/// <remarks/>
		public UserInfo Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((UserInfo)(this.results[0]));
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	public delegate void ChangeUserPasswordByUsernameCompletedEventHandler(object sender, ChangeUserPasswordByUsernameCompletedEventArgs e);

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class ChangeUserPasswordByUsernameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{

		private object[] results;

		internal ChangeUserPasswordByUsernameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
			base(exception, cancelled, userState)
		{
			this.results = results;
		}

		/// <remarks/>
		public int Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((int)(this.results[0]));
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	public delegate void SendPasswordReminderCompletedEventHandler(object sender, SendPasswordReminderCompletedEventArgs e);

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class SendPasswordReminderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{

		private object[] results;

		internal SendPasswordReminderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
			base(exception, cancelled, userState)
		{
			this.results = results;
		}

		/// <remarks/>
		public int Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((int)(this.results[0]));
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	public delegate void GetSystemSetupModeCompletedEventHandler(object sender, GetSystemSetupModeCompletedEventArgs e);

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class GetSystemSetupModeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{

		private object[] results;

		internal GetSystemSetupModeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
			base(exception, cancelled, userState)
		{
			this.results = results;
		}

		/// <remarks/>
		public bool Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((bool)(this.results[0]));
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	public delegate void SetupControlPanelAccountsCompletedEventHandler(object sender, SetupControlPanelAccountsCompletedEventArgs e);

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class SetupControlPanelAccountsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
	{

		private object[] results;

		internal SetupControlPanelAccountsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
			base(exception, cancelled, userState)
		{
			this.results = results;
		}

		/// <remarks/>
		public int Result
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((int)(this.results[0]));
			}
		}
	}
}
