using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType {
    public interface IPhbkPhoneTypeViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IPhbkPhoneTypeView rw, string nvNm);
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


        Task<IList<IPhbkPhoneTypeView>> getall();
        Task<IPhbkPhoneTypeViewPage> getwithfilter(IPhbkPhoneTypeViewFilter filter);
        Task<IPhbkPhoneTypeView> getone(
        System.Int32 PhoneTypeId 
        );
        Task<IPhbkPhoneTypeViewPage> getmanybyrepprim(IPhbkPhoneTypeViewFilter filter);

        Task<IPhbkPhoneTypeView> updateone(IPhbkPhoneTypeView item);
        Task<IPhbkPhoneTypeView> addone(IPhbkPhoneTypeView item);
        Task<IPhbkPhoneTypeView> deleteone(System.Int32 PhoneTypeId );
        IPhbkPhoneTypeViewNotify CopyToModelNotify(IPhbkPhoneTypeView  src, IPhbkPhoneTypeViewNotify dest = null);
        IPhbkPhoneTypeView CopyToModel(IPhbkPhoneTypeView  src, IPhbkPhoneTypeView dest = null);
        IPhbkPhoneTypeViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IPhbkPhoneTypeView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IPhbkPhoneTypeView r);
        IPhbkPhoneTypeViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IPhbkPhoneTypeViewFilter dest);
        IPhbkPhoneTypeViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IPhbkPhoneTypeViewFilter dest);
    }
}

