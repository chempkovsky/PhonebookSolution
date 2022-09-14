using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprEmployee02 {
    public interface ILprEmployee02ViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprEmployee02View rw, string nvNm);
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


        Task<IList<ILprEmployee02View>> getall();
        Task<ILprEmployee02ViewPage> getwithfilter(ILprEmployee02ViewFilter filter);
        Task<ILprEmployee02View> getone(
        System.Int32 DivisionIdRef 
        , System.Int32 EmpLastNameIdRef 
        , System.Int32 EmpFirstNameIdRef 
        , System.Int32 EmpSecondNameIdRef 
        , System.Int32 EmployeeId 
        );
        Task<ILprEmployee02ViewPage> getmanybyrepprim(ILprEmployee02ViewFilter filter);

        Task<ILprEmployee02View> updateone(ILprEmployee02View item);
        Task<ILprEmployee02View> addone(ILprEmployee02View item);
        Task<ILprEmployee02View> deleteone(System.Int32 DivisionIdRef , System.Int32 EmpLastNameIdRef , System.Int32 EmpFirstNameIdRef , System.Int32 EmpSecondNameIdRef , System.Int32 EmployeeId );
        ILprEmployee02ViewNotify CopyToModelNotify(ILprEmployee02View  src, ILprEmployee02ViewNotify dest = null);
        ILprEmployee02View CopyToModel(ILprEmployee02View  src, ILprEmployee02View dest = null);
        ILprEmployee02ViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprEmployee02View r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprEmployee02View r);
        ILprEmployee02ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprEmployee02ViewFilter dest);
        ILprEmployee02ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprEmployee02ViewFilter dest);
    }
}

