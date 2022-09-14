using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone03 {
    public interface ILprPhone03ViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprPhone03View rw, string nvNm);
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


        Task<IList<ILprPhone03View>> getall();
        Task<ILprPhone03ViewPage> getwithfilter(ILprPhone03ViewFilter filter);
        Task<ILprPhone03View> getone(
        System.Int32 PhoneTypeIdRef 
        , System.Int32 LpdPhoneIdRef 
        , System.Int32 PhoneId 
        );
        Task<ILprPhone03ViewPage> getmanybyrepprim(ILprPhone03ViewFilter filter);

        Task<ILprPhone03View> updateone(ILprPhone03View item);
        Task<ILprPhone03View> addone(ILprPhone03View item);
        Task<ILprPhone03View> deleteone(System.Int32 PhoneTypeIdRef , System.Int32 LpdPhoneIdRef , System.Int32 PhoneId );
        ILprPhone03ViewNotify CopyToModelNotify(ILprPhone03View  src, ILprPhone03ViewNotify dest = null);
        ILprPhone03View CopyToModel(ILprPhone03View  src, ILprPhone03View dest = null);
        ILprPhone03ViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprPhone03View r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprPhone03View r);
        ILprPhone03ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprPhone03ViewFilter dest);
        ILprPhone03ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprPhone03ViewFilter dest);
    }
}

