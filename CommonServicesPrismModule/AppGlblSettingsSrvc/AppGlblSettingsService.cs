using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Interfaces;
/*
    "AppGlblSettingsService"  is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            IAppGlblSettingsService s = new AppGlblSettingsService();
            containerRegistry.RegisterInstance<IAppGlblSettingsService>(s);
            ...
        }
*/

namespace CommonServicesPrismModule.AppGlblSettingsSrvc
{
    public class AppGlblSettingsService : IAppGlblSettingsService
    {
        public string CurrNavPath { get; set; } = "";
        double _FilterHeightAddition = 0;
        double _FilterHeightFactor = 70;
        double _TableHeightAddition = 33.8;
        double _TableHeightFactor = 33.6;
        double _DeviceHeight = 1080;


        public AppGlblSettingsService()
        {
            DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            _DeviceHeight = mainDisplayInfo.Height / mainDisplayInfo.Density;
        }

        public double DefaultGridRows(string fileType)
        {
            switch (fileType)
            {
                case "01698-O2mUserControl.xaml":
                case "01699-O2mPage.xaml":
                    return 5d;
                default:
                    return 6d;
            }
        }
        public double DefaultFilterRows(string fileType)
        {
            switch (fileType)
            {
                case "01698-O2mUserControl.xaml":
                case "01699-O2mPage.xaml":
                    return 1d;
                default:
                    return 1d;
            }
        }
        public double ExpandedGridRows(string fileType)
        {
            switch (fileType)
            {
                case "01698-O2mUserControl.xaml":
                case "01699-O2mPage.xaml":
                    return 5d;
                default:
                    if (_DeviceHeight < 1080d)
                    {
                        return 8d;
                    }
                    else
                    {
                        return 18d;
                    }
            }
        }
        public double ExpandedFilterRows(string fileType)
        {
            switch (fileType)
            {
                case "01698-O2mUserControl.xaml":
                case "01699-O2mPage.xaml":
                    return 1d;
                default:
                    return 2d;
            }
        }
        public double DefaultGridHeight(string fileType)
        {
            return DefaultGridRows(fileType) * TableHeightFactor + TableHeightAddition;
        }
        public double DefaultFilterHeight(string fileType)
        {
            return DefaultFilterRows(fileType) * FilterHeightFactor + FilterHeightAddition;
        }
        public double ExpandedGridHeight(string fileType)
        {
            return ExpandedGridRows(fileType) * TableHeightFactor + TableHeightAddition;
        }
        public double ExpandedFilterHeight(string fileType)
        {
            return ExpandedFilterRows(fileType) * FilterHeightFactor + FilterHeightAddition;
        }

        public double FilterHeightAddition {
            get {
                return _FilterHeightAddition;
            }
            set {
                _FilterHeightAddition = value;
            }
        }
        public double FilterHeightFactor {
            get {
                return _FilterHeightFactor;
            }
            set {
                _FilterHeightFactor = value;
            }
        }
        public double TableHeightAddition {
            get {
                return _TableHeightAddition;
            }
            set {
                _TableHeightAddition = value;
            }
        }
        public double TableHeightFactor {
            get {
                return _TableHeightFactor;
            }
            set {
                _TableHeightFactor = value;
            }
        }
        public event Action<object, string> OnMessageNotification;
        public event Action<object, string> OnUserChangedNotification;
        public event Action<object, string> OnNavigateToNotification;
        public string GetWebApiPrefix(string ViewName)
        {
            string rslt = "";
            if (!string.IsNullOrEmpty(ViewName))
            {
                if (ViewName.StartsWith("Lpd") || ViewName.StartsWith("Lpr"))
                {
                    if (Device.RuntimePlatform == Device.Android)
                    {

                        rslt = "http://10.0.2.2:5055/";
                    }
                    else
                    {
                        return "http://localhost:5055/";
                    }

                }
                else
                {
                    if (Device.RuntimePlatform == Device.Android)
                    {

                        rslt = "http://10.0.2.2:5165/";
                    }
                    else
                    {
                        return "http://localhost:5165/";
                    }
                }
            }
            return rslt;
        }
        public string GetSecurityWebApiPrefix()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                return "http://10.0.2.2:52157/";
            }
            else
            {
                return "http://localhost:5165/";
            }
        }
        public double getDialogWidth(string ViewName)
        {
            double rslt = 90;
            if (!string.IsNullOrEmpty(ViewName))
            {
                rslt = 90;
            }
            return rslt;
        }
        protected string _UserName = string.Empty;
        public string UserName {
            get {
                return _UserName;
            }
            set {
                if (_UserName != value)
                {
                    _UserName = value;
                    if (OnUserChangedNotification != null)
                    {
                        OnUserChangedNotification(this, _UserName);
                    }
                }
            }
        }
        protected IBearerTokenModel _AuthInfo = null;
        public IBearerTokenModel AuthInfo {
            get {
                return _AuthInfo;
            }
            set {
                if (_AuthInfo != value)
                {
                    _AuthInfo = value;
                    if (_AuthInfo == null)
                    {
                        Client.DefaultRequestHeaders.Authorization = null;
                    }
                    else if ((AuthInfo.token_type == null) || (AuthInfo.access_token == null))
                    {
                        Client.DefaultRequestHeaders.Authorization = null;
                    }
                    else
                    {
                        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthInfo.token_type, AuthInfo.access_token);
                    }
                }
            }
        }
        public List<KeyValuePair<string, string>> GetAuthInfoHeader()
        {
            List<KeyValuePair<string, string>> rslt = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("content-type","application/json"),
                new KeyValuePair<string, string>("accept","application/json"),
                new KeyValuePair<string, string>("accept","text/plain"),
                new KeyValuePair<string, string>("accept","*/*"),
            };
            if (AuthInfo != null)
            {
                rslt.Add(new KeyValuePair<string, string>("Authorization", (AuthInfo.token_type as string) + " " + (AuthInfo.access_token as string)));
            }
            return rslt;
        }
        Dictionary<string, int> Views = new Dictionary<string, int>()
        {
            { "LitAuthorView", 0 },
            { "LitBookView", 1 },
        };
        Dictionary<string, int> Dashboards = new Dictionary<string, int>()
        {
            { "ManuscriptDFeatureFtrComponent", 0 },
            { "ManuscriptRFeatureFtrComponent", 1 },
        };
        int[] _Permissions = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] Permissions {
            get {
                return _Permissions;
            }
            set {
                _Permissions = value;
            }
        }
        public int[] GetEmptyPermissions()
        {
            return new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
        public int GetViewModelMask(string vwModel)
        {

            return 31; // delete this line when vwModels is ready
            if (Permissions == null) return 0;
            int pk = 0;
            if (!Views.TryGetValue(vwModel, out pk)) return 0;
            int rid = pk / 7;
            if (rid >= (Permissions.Count() - 3)) return 0;
            int sft = (pk - rid * 7) * 4;
            int rslt = Permissions[rid];
            if (sft > 0)
            {
                rslt >>= sft;
            }
            return rslt;
        }
        public int GetDashBrdMask(string dshBrd)
        {
            return 31; // delete this line when dshBrds is ready
            if (Dashboards == null) return 0;
            int pk = 0;
            if (!Dashboards.TryGetValue(dshBrd, out pk)) return 0;
            int rid = pk / 31;
            if (rid >= (Permissions.Count() - 14)) return 0;
            int sft = (pk - rid * 31);
            int rslt = Permissions[rid + 14];
            if (sft > 0)
            {
                rslt >>= sft;
            }
            return rslt;
        }
        protected HttpClient _Client = null;
        public HttpClient Client {
            get {
                if (_Client == null)
                {
                    _Client = new HttpClient();
                    _Client.DefaultRequestHeaders.Add("Accept", "application/json");
                    _Client.DefaultRequestHeaders.Add("Accept", "text/plain");
                    _Client.DefaultRequestHeaders.Add("Accept", "*/*");
                    _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (AuthInfo != null)
                    {
                        if ((AuthInfo.token_type != null) || (AuthInfo.access_token != null))
                        {
                            _Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthInfo.token_type, AuthInfo.access_token);
                        }
                    }
                }
                return _Client;
            }
        }
        public void ShowErrorMessage(string errorType, string errorMsg)
        {
            OnMessageNotification?.Invoke(this, errorType + ": " + errorMsg);
        }
        public void NavigateTo(string navigationPath)
        {
            OnNavigateToNotification?.Invoke(this, navigationPath);
        }
        public bool DelayActivated { get; set; } = false;
    }
}

