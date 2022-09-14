using System;
using System.Collections.Generic;
using System.Net.Http;
using CommonInterfacesClassLibrary.Interfaces;

namespace CommonInterfacesClassLibrary.AppGlblSettingsSrvc {
    public interface  IAppGlblSettingsService
    {
        string CurrNavPath { get; set; }
        double FilterHeightAddition { get; set; }
        double FilterHeightFactor { get; set; }
        double TableHeightAddition { get; set; }
        double TableHeightFactor { get; set; }
        event Action<object, string> OnMessageNotification;
        event Action<object, string> OnUserChangedNotification;
        event Action<object, string> OnNavigateToNotification;
        string GetWebApiPrefix(string ViewName);
        string GetSecurityWebApiPrefix();
        double getDialogWidth(string ViewName);
        string UserName { get; set; }
        IBearerTokenModel AuthInfo { get; set; }
        List<KeyValuePair<string, string>> GetAuthInfoHeader();
        int[] Permissions { get; set; }
        int[] GetEmptyPermissions();
        int GetViewModelMask(string vwModel);
        int GetDashBrdMask(string dshBrd);
        HttpClient Client  { get; }
        void ShowErrorMessage(string errorType, string errorMsg);
        void NavigateTo(string navigationPath);

        double DefaultGridRows(string fileType);
        double DefaultFilterRows(string fileType);
        double ExpandedGridRows(string fileType);
        double ExpandedFilterRows(string fileType);
        double DefaultGridHeight(string fileType);
        double DefaultFilterHeight(string fileType);
        double ExpandedGridHeight(string fileType);
        double ExpandedFilterHeight(string fileType);
        bool   DelayActivated { get; set; }
    }
}

