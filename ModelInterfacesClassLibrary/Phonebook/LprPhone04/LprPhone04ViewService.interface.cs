using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone04 {
    public interface ILprPhone04ViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprPhone04View rw, string nvNm);
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


        Task<IList<ILprPhone04View>> getall();
        Task<ILprPhone04ViewPage> getwithfilter(ILprPhone04ViewFilter filter);
        Task<ILprPhone04View> getone(
        System.Int32 EmployeeIdRef 
        , System.Int32 PhoneTypeIdRef 
        , System.Int32 LpdPhoneIdRef 
        , System.Int32 PhoneId 
        );
        Task<ILprPhone04ViewPage> getmanybyrepprim(ILprPhone04ViewFilter filter);

        Task<ILprPhone04View> updateone(ILprPhone04View item);
        Task<ILprPhone04View> addone(ILprPhone04View item);
        Task<ILprPhone04View> deleteone(System.Int32 EmployeeIdRef , System.Int32 PhoneTypeIdRef , System.Int32 LpdPhoneIdRef , System.Int32 PhoneId );
        ILprPhone04ViewNotify CopyToModelNotify(ILprPhone04View  src, ILprPhone04ViewNotify dest = null);
        ILprPhone04View CopyToModel(ILprPhone04View  src, ILprPhone04View dest = null);
        ILprPhone04ViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprPhone04View r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprPhone04View r);
        ILprPhone04ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprPhone04ViewFilter dest);
        ILprPhone04ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprPhone04ViewFilter dest);
    }
}

