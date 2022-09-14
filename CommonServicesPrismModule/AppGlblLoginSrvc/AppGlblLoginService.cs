using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.AppGlblLoginSrvc;
using CommonInterfacesClassLibrary.Interfaces;
using CommonServicesPrismModule.Models;

/*
    "AppGlblLoginService"  is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            containerRegistry.Register<IAppGlblLoginService, AppGlblLoginService>();
            ...
        }

*/

namespace CommonServicesPrismModule.AppGlblLoginSrvc {
    public class AppGlblLoginService: IAppGlblLoginService
    {
        protected IAppGlblSettingsService GlblSettingsSrv = null;
        protected string serviceUrl = null;
        protected HttpClient client = null;
        public AppGlblLoginService(IAppGlblSettingsService agstt) {
            this.GlblSettingsSrv = agstt;
            this.serviceUrl = this.GlblSettingsSrv.GetSecurityWebApiPrefix();
            this.client = this.GlblSettingsSrv.Client;
        }

        public async Task<IBearerTokenModel> Login(string Email, string Password)
        {
            try
            {
                var stringContent = new StringContent(
                    Uri.EscapeDataString("username") + "=" + Uri.EscapeDataString(Email) + "&" +
                    Uri.EscapeDataString("password") + "=" + Uri.EscapeDataString(Password) + "&" +
                    Uri.EscapeDataString("grant_type") + "=" + Uri.EscapeDataString("password") , 
                    Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(serviceUrl + "token", stringContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BearerTokenModel>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "AppGlblLoginService.Login : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }


        public async Task<IRegisterModel> Register(string Email, string Password, string ConfirmPassword) {
            IRegisterModel model = GetRegisterModel(Email, Password, ConfirmPassword);
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(serviceUrl + "api/Account/Register",  stringContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  model; //JsonConvert.DeserializeObject<RegisterModel>(responseBody) ;

            } 
            catch(Exception e) 
            {
                string exceptionMsg = "AppGlblLoginService.Register : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }

        public async Task<bool> Logout() {
            try
            {
                HttpResponseMessage response = await client.PostAsync(serviceUrl + "api/Account/Logout",  null);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  true; //JsonConvert.DeserializeObject<RegisterModel>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "AppGlblLoginService.Logout : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                return false;
            }
        }

        public async Task<IChangePasswordModel> ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword) {
            IChangePasswordModel model = GetChangePasswordModel(OldPassword, NewPassword, ConfirmPassword);
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(serviceUrl + "api/Account/ChangePassword",  stringContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  model; //JsonConvert.DeserializeObject<ChangePasswordModel>(responseBody) ;

            } 
            catch(Exception e) 
            {
                string exceptionMsg = "AppGlblLoginService.ChangePassword : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                GlblSettingsSrv.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }

        public IChangePasswordModel GetChangePasswordModel(string OldPassword, string NewPassword, string ConfirmPassword) {
            return new ChangePasswordModel() {
                OldPassword = OldPassword,
                NewPassword = NewPassword,
                ConfirmPassword = ConfirmPassword
            };
        }

        public IRegisterModel GetRegisterModel(string Email, string Password, string ConfirmPassword) {
            return new RegisterModel() {
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };
        }
    }
}

