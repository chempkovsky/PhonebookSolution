using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone02 {
    public interface ILprPhone02ViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprPhone02View rw, string nvNm);
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


        Task<IList<ILprPhone02View>> getall();
        Task<ILprPhone02ViewPage> getwithfilter(ILprPhone02ViewFilter filter);
        Task<ILprPhone02View> getone(
        System.Int32 EmployeeIdRef 
        , System.Int32 LpdPhoneIdRef 
        , System.Int32 PhoneId 
        );
        Task<ILprPhone02ViewPage> getmanybyrepprim(ILprPhone02ViewFilter filter);

        Task<ILprPhone02View> updateone(ILprPhone02View item);
        Task<ILprPhone02View> addone(ILprPhone02View item);
        Task<ILprPhone02View> deleteone(System.Int32 EmployeeIdRef , System.Int32 LpdPhoneIdRef , System.Int32 PhoneId );
        ILprPhone02ViewNotify CopyToModelNotify(ILprPhone02View  src, ILprPhone02ViewNotify dest = null);
        ILprPhone02View CopyToModel(ILprPhone02View  src, ILprPhone02View dest = null);
        ILprPhone02ViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprPhone02View r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprPhone02View r);
        ILprPhone02ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprPhone02ViewFilter dest);
        ILprPhone02ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprPhone02ViewFilter dest);
    }
}

