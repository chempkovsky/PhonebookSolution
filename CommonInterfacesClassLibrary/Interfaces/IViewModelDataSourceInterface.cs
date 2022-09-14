using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IViewModelDataSourceInterface
    {
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByFltRslt(IList<IWebServiceFilterRsltInterface> fr);
        string getUIFormChain();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilter();
        void setHiddenFilter(Dictionary<(string viewNm, string navNm, string propNm), object> fltr);
        string getCurrentViewName();
        string getClientViewName();
        string getDirectNavigation();
        bool getIsTopDetail();
        bool getIsDefined();
        int getLength();
        Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>.KeyCollection getKeys();
        object getValue(string key);
        void setValue(string key, object value);
        bool requiredValue(string key);
        bool dbgeneratedValue(string key);
        bool isInPrimkeyValue(string key);
        bool isSetValue(string key); 
        void clearValue(string key);
        bool Clear(bool doNotify);
        bool isEqual(object src, object dest, string dttp);

        event EventHandler OnDetailChanged;
        event EventHandler OnMasterChanged;
        event EventHandler AfterMasterChanged;
        event EventHandler AfterPropsChanged;
        event EventHandler OnIsDefinedChanged;
        event EventHandler OnUpdate;
        event EventHandler OnAdd;
        event EventHandler OnDelete;

        bool ClearPartially(bool doNotify);
        void SubmitOnDetailChanged(object sender, EventArgs e);
        Task DoSubmitOnDetailChanged(object sender);
        void SubmitOnMasterChanged(object sender, EventArgs e);
        void DoSubmitOnMasterChanged(object sender);
        bool CalcIsDefined();
        void DoEmitEvent(bool aftrMstrChngd=false);

        bool RefreshIsDefined();
        bool IsSetFilterByCurrDirMstrs();
        Task updateone();
        Task addone();
        Task deleteone();
        Task Refresh();
        bool isUnderHiddenFilterFields(string fld);
        bool UpdateByHiddenFilterFields(bool doNotify = true);
        bool getIsNew();
        void setIsNew(bool v);
        bool isReadonlyValue(string key);
        void Init(string ClientViewName, string DirectNavigation, IList<string> CurrentlyDirectMasterNavs, string UIFormChain);
        object getByOrgValue(string org, string fkchain);
        void setByOrgValue(string org, string fkchain, object value);
    }
}

