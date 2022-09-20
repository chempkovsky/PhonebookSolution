using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetusermaskView {
    public interface IAspnetusermaskViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IAspnetusermaskView rw, string nvNm);
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


        Task<IaspnetusermaskViewPage> getwithfilter(IAspnetusermaskViewFilter filter);
        IAspnetusermaskViewNotify CopyToModelNotify(IAspnetusermaskView  src, IAspnetusermaskViewNotify dest = null);
        IAspnetusermaskView CopyToModel(IAspnetusermaskView  src, IAspnetusermaskView dest = null);
        IAspnetusermaskViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IAspnetusermaskView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IAspnetusermaskView r);
        IAspnetusermaskViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IAspnetusermaskViewFilter dest);
        IAspnetusermaskViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IAspnetusermaskViewFilter dest);
    }
}

