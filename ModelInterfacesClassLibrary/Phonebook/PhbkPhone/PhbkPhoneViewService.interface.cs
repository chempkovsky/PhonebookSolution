using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkPhone {
    public interface IPhbkPhoneViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IPhbkPhoneView rw, string nvNm);
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


        Task<IList<IPhbkPhoneView>> getall();
        Task<IPhbkPhoneViewPage> getwithfilter(IPhbkPhoneViewFilter filter);
        Task<IPhbkPhoneView> getone(
        System.Int32 PhoneId 
        );
        Task<IPhbkPhoneViewPage> getmanybyrepprim(IPhbkPhoneViewFilter filter);

        Task<IPhbkPhoneView> updateone(IPhbkPhoneView item);
        Task<IPhbkPhoneView> addone(IPhbkPhoneView item);
        Task<IPhbkPhoneView> deleteone(System.Int32 PhoneId );
        IPhbkPhoneViewNotify CopyToModelNotify(IPhbkPhoneView  src, IPhbkPhoneViewNotify dest = null);
        IPhbkPhoneView CopyToModel(IPhbkPhoneView  src, IPhbkPhoneView dest = null);
        IPhbkPhoneViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IPhbkPhoneView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IPhbkPhoneView r);
        IPhbkPhoneViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IPhbkPhoneViewFilter dest);
        IPhbkPhoneViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IPhbkPhoneViewFilter dest);
    }
}

