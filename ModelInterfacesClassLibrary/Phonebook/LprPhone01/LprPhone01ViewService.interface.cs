using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone01 {
    public interface ILprPhone01ViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprPhone01View rw, string nvNm);
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


        Task<IList<ILprPhone01View>> getall();
        Task<ILprPhone01ViewPage> getwithfilter(ILprPhone01ViewFilter filter);
        Task<ILprPhone01View> getone(
        System.Int32 LpdPhoneIdRef 
        , System.Int32 PhoneId 
        );
        Task<ILprPhone01ViewPage> getmanybyrepprim(ILprPhone01ViewFilter filter);

        Task<ILprPhone01View> updateone(ILprPhone01View item);
        Task<ILprPhone01View> addone(ILprPhone01View item);
        Task<ILprPhone01View> deleteone(System.Int32 LpdPhoneIdRef , System.Int32 PhoneId );
        ILprPhone01ViewNotify CopyToModelNotify(ILprPhone01View  src, ILprPhone01ViewNotify dest = null);
        ILprPhone01View CopyToModel(ILprPhone01View  src, ILprPhone01View dest = null);
        ILprPhone01ViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprPhone01View r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprPhone01View r);
        ILprPhone01ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprPhone01ViewFilter dest);
        ILprPhone01ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprPhone01ViewFilter dest);
    }
}

