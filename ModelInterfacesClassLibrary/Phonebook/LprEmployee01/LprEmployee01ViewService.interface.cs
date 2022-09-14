using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprEmployee01 {
    public interface ILprEmployee01ViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprEmployee01View rw, string nvNm);
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


        Task<IList<ILprEmployee01View>> getall();
        Task<ILprEmployee01ViewPage> getwithfilter(ILprEmployee01ViewFilter filter);
        Task<ILprEmployee01View> getone(
        System.Int32 EmpLastNameIdRef 
        , System.Int32 EmpFirstNameIdRef 
        , System.Int32 EmpSecondNameIdRef 
        , System.Int32 EmployeeId 
        );
        Task<ILprEmployee01ViewPage> getmanybyrepprim(ILprEmployee01ViewFilter filter);

        Task<ILprEmployee01View> updateone(ILprEmployee01View item);
        Task<ILprEmployee01View> addone(ILprEmployee01View item);
        Task<ILprEmployee01View> deleteone(System.Int32 EmpLastNameIdRef , System.Int32 EmpFirstNameIdRef , System.Int32 EmpSecondNameIdRef , System.Int32 EmployeeId );
        ILprEmployee01ViewNotify CopyToModelNotify(ILprEmployee01View  src, ILprEmployee01ViewNotify dest = null);
        ILprEmployee01View CopyToModel(ILprEmployee01View  src, ILprEmployee01View dest = null);
        ILprEmployee01ViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprEmployee01View r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprEmployee01View r);
        ILprEmployee01ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprEmployee01ViewFilter dest);
        ILprEmployee01ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprEmployee01ViewFilter dest);
    }
}

