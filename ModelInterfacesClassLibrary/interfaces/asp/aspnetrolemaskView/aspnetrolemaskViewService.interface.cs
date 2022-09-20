using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView {
    public interface IAspnetrolemaskViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IAspnetrolemaskView rw, string nvNm);
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


        Task<IList<IAspnetrolemaskView>> getall();
        Task<IaspnetrolemaskViewPage> getwithfilter(IAspnetrolemaskViewFilter filter);
        Task<IAspnetrolemaskView> getone(
        System.String RName 
        , System.Int32 ModelPkRef 
        );
        Task<IaspnetrolemaskViewPage> getmanybyrepprim(IAspnetrolemaskViewFilter filter);

        Task<IAspnetrolemaskView> updateone(IAspnetrolemaskView item);
        Task<IAspnetrolemaskView> addone(IAspnetrolemaskView item);
        Task<IAspnetrolemaskView> deleteone(System.String RName , System.Int32 ModelPkRef );
        IAspnetrolemaskViewNotify CopyToModelNotify(IAspnetrolemaskView  src, IAspnetrolemaskViewNotify dest = null);
        IAspnetrolemaskView CopyToModel(IAspnetrolemaskView  src, IAspnetrolemaskView dest = null);
        IAspnetrolemaskViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IAspnetrolemaskView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IAspnetrolemaskView r);
        IAspnetrolemaskViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IAspnetrolemaskViewFilter dest);
        IAspnetrolemaskViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IAspnetrolemaskViewFilter dest);
    }
}

