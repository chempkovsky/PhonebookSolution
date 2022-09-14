using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprDivision01 {
    public interface ILprDivision01ViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprDivision01View rw, string nvNm);
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


        Task<IList<ILprDivision01View>> getall();
        Task<ILprDivision01ViewPage> getwithfilter(ILprDivision01ViewFilter filter);
        Task<ILprDivision01View> getone(
        System.Int32 DivisionNameIdRef 
        , System.Int32 DivisionId 
        );
        Task<ILprDivision01ViewPage> getmanybyrepprim(ILprDivision01ViewFilter filter);

        Task<ILprDivision01View> updateone(ILprDivision01View item);
        Task<ILprDivision01View> addone(ILprDivision01View item);
        Task<ILprDivision01View> deleteone(System.Int32 DivisionNameIdRef , System.Int32 DivisionId );
        ILprDivision01ViewNotify CopyToModelNotify(ILprDivision01View  src, ILprDivision01ViewNotify dest = null);
        ILprDivision01View CopyToModel(ILprDivision01View  src, ILprDivision01View dest = null);
        ILprDivision01ViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprDivision01View r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprDivision01View r);
        ILprDivision01ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprDivision01ViewFilter dest);
        ILprDivision01ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprDivision01ViewFilter dest);
    }
}

