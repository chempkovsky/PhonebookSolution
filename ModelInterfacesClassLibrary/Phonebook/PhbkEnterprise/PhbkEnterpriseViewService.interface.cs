using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise {
    public interface IPhbkEnterpriseViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IPhbkEnterpriseView rw, string nvNm);
        int getLength();
        Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>.KeyCollection getKeys();
        string getDtTpValue(string key);
        string getFkValue(string key);
        bool requiredValue(string key);
        bool dbgeneratedValue(string key);
        bool isInPrimkeyValue(string key);
        bool IsInUnkKeyValue(string key);
        string getKeyByOrgValue(string org, string fkchain);
        IList<IWebServiceFilterRsltInterface> getHiddenFilterAsFltRslt(Dictionary<(string viewNm, string navNm, string propNm), object> HiddenFilter);
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByFltRslt(IList<IWebServiceFilterRsltInterface> fr);
        Dictionary<(string viewNm, string navNm, string propNm), string> getC2mfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> Dict2Tuple(Dictionary<string, object> src);
        Dictionary<string, object> Tuple2Dict(Dictionary<(string viewNm, string navNm, string propNm), object> src);


        Task<IList<IPhbkEnterpriseView>> getall();
        Task<IPhbkEnterpriseViewPage> getwithfilter(IPhbkEnterpriseViewFilter filter);
        Task<IPhbkEnterpriseView> getone(
        System.Int32 EntrprsId 
        );
        Task<IPhbkEnterpriseViewPage> getmanybyrepprim(IPhbkEnterpriseViewFilter filter);

        Task<IPhbkEnterpriseView> getonebyEntrprsNameUK(
        System.String EntrprsName 
        );
        Task<IPhbkEnterpriseViewPage> getmanybyrepunqEntrprsNameUK(IPhbkEnterpriseViewFilter filter);

        Task<IPhbkEnterpriseView> updateone(IPhbkEnterpriseView item);
        Task<IPhbkEnterpriseView> addone(IPhbkEnterpriseView item);
        Task<IPhbkEnterpriseView> deleteone(System.Int32 EntrprsId );
        IPhbkEnterpriseViewNotify CopyToModelNotify(IPhbkEnterpriseView  src, IPhbkEnterpriseViewNotify dest = null);
        IPhbkEnterpriseView CopyToModel(IPhbkEnterpriseView  src, IPhbkEnterpriseView dest = null);
        IPhbkEnterpriseViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IPhbkEnterpriseView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IPhbkEnterpriseView r);
        IPhbkEnterpriseViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IPhbkEnterpriseViewFilter dest);
        IPhbkEnterpriseViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IPhbkEnterpriseViewFilter dest);
    }
}

