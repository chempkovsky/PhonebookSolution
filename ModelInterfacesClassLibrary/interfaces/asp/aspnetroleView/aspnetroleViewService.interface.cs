using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView {
    public interface IAspnetroleViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IAspnetroleView rw, string nvNm);
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


        Task<IList<IAspnetroleView>> getall();
        Task<IaspnetroleViewPage> getwithfilter(IAspnetroleViewFilter filter);
        Task<IAspnetroleView> getone(
        System.String Id 
        );
        Task<IaspnetroleViewPage> getmanybyrepprim(IAspnetroleViewFilter filter);

        Task<IAspnetroleView> getonebyUnqName(
        System.String Name 
        );
        Task<IaspnetroleViewPage> getmanybyrepunqUnqName(IAspnetroleViewFilter filter);

        Task<IAspnetroleView> updateone(IAspnetroleView item);
        Task<IAspnetroleView> addone(IAspnetroleView item);
        Task<IAspnetroleView> deleteone(System.String Id );
        IAspnetroleViewNotify CopyToModelNotify(IAspnetroleView  src, IAspnetroleViewNotify dest = null);
        IAspnetroleView CopyToModel(IAspnetroleView  src, IAspnetroleView dest = null);
        IAspnetroleViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IAspnetroleView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IAspnetroleView r);
        IAspnetroleViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IAspnetroleViewFilter dest);
        IAspnetroleViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IAspnetroleViewFilter dest);
    }
}

