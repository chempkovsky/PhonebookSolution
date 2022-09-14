using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkDivision {
    public interface IPhbkDivisionViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IPhbkDivisionView rw, string nvNm);
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


        Task<IList<IPhbkDivisionView>> getall();
        Task<IPhbkDivisionViewPage> getwithfilter(IPhbkDivisionViewFilter filter);
        Task<IPhbkDivisionView> getone(
        System.Int32 DivisionId 
        );
        Task<IPhbkDivisionViewPage> getmanybyrepprim(IPhbkDivisionViewFilter filter);

        Task<IPhbkDivisionView> updateone(IPhbkDivisionView item);
        Task<IPhbkDivisionView> addone(IPhbkDivisionView item);
        Task<IPhbkDivisionView> deleteone(System.Int32 DivisionId );
        IPhbkDivisionViewNotify CopyToModelNotify(IPhbkDivisionView  src, IPhbkDivisionViewNotify dest = null);
        IPhbkDivisionView CopyToModel(IPhbkDivisionView  src, IPhbkDivisionView dest = null);
        IPhbkDivisionViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IPhbkDivisionView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IPhbkDivisionView r);
        IPhbkDivisionViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IPhbkDivisionViewFilter dest);
        IPhbkDivisionViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IPhbkDivisionViewFilter dest);
    }
}

