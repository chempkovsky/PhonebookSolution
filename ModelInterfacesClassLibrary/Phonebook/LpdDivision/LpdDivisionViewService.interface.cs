using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdDivision {
    public interface ILpdDivisionViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILpdDivisionView rw, string nvNm);
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


        Task<IList<ILpdDivisionView>> getall();
        Task<ILpdDivisionViewPage> getwithfilter(ILpdDivisionViewFilter filter);
        Task<ILpdDivisionView> getone(
        System.Int32 DivisionNameId 
        );
        Task<ILpdDivisionViewPage> getmanybyrepprim(ILpdDivisionViewFilter filter);

        Task<ILpdDivisionView> getonebyLpdDivisionNameUk(
        System.String DivisionName 
        );
        Task<ILpdDivisionViewPage> getmanybyrepunqLpdDivisionNameUk(ILpdDivisionViewFilter filter);

        Task<ILpdDivisionView> updateone(ILpdDivisionView item);
        Task<ILpdDivisionView> addone(ILpdDivisionView item);
        Task<ILpdDivisionView> deleteone(System.Int32 DivisionNameId );
        ILpdDivisionViewNotify CopyToModelNotify(ILpdDivisionView  src, ILpdDivisionViewNotify dest = null);
        ILpdDivisionView CopyToModel(ILpdDivisionView  src, ILpdDivisionView dest = null);
        ILpdDivisionViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILpdDivisionView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILpdDivisionView r);
        ILpdDivisionViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILpdDivisionViewFilter dest);
        ILpdDivisionViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILpdDivisionViewFilter dest);
    }
}

