using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView {
    public interface IAspnetuserViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IAspnetuserView rw, string nvNm);
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


        Task<IList<IAspnetuserView>> getall();
        Task<IaspnetuserViewPage> getwithfilter(IAspnetuserViewFilter filter);
        Task<IAspnetuserView> getone(
        System.String Id 
        );
        Task<IaspnetuserViewPage> getmanybyrepprim(IAspnetuserViewFilter filter);

        Task<IAspnetuserView> updateone(IAspnetuserView item);
        Task<IAspnetuserView> addone(IAspnetuserView item);
        Task<IAspnetuserView> deleteone(System.String Id );
        IAspnetuserViewNotify CopyToModelNotify(IAspnetuserView  src, IAspnetuserViewNotify dest = null);
        IAspnetuserView CopyToModel(IAspnetuserView  src, IAspnetuserView dest = null);
        IAspnetuserViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IAspnetuserView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IAspnetuserView r);
        IAspnetuserViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IAspnetuserViewFilter dest);
        IAspnetuserViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IAspnetuserViewFilter dest);
    }
}

