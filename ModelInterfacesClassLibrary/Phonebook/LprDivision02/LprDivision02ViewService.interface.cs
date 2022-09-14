using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprDivision02 {
    public interface ILprDivision02ViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprDivision02View rw, string nvNm);
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


        Task<IList<ILprDivision02View>> getall();
        Task<ILprDivision02ViewPage> getwithfilter(ILprDivision02ViewFilter filter);
        Task<ILprDivision02View> getone(
        System.Int32 EntrprsIdRef 
        , System.Int32 DivisionNameIdRef 
        , System.Int32 DivisionId 
        );
        Task<ILprDivision02ViewPage> getmanybyrepprim(ILprDivision02ViewFilter filter);

        Task<ILprDivision02View> updateone(ILprDivision02View item);
        Task<ILprDivision02View> addone(ILprDivision02View item);
        Task<ILprDivision02View> deleteone(System.Int32 EntrprsIdRef , System.Int32 DivisionNameIdRef , System.Int32 DivisionId );
        ILprDivision02ViewNotify CopyToModelNotify(ILprDivision02View  src, ILprDivision02ViewNotify dest = null);
        ILprDivision02View CopyToModel(ILprDivision02View  src, ILprDivision02View dest = null);
        ILprDivision02ViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprDivision02View r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprDivision02View r);
        ILprDivision02ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprDivision02ViewFilter dest);
        ILprDivision02ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprDivision02ViewFilter dest);
    }
}

