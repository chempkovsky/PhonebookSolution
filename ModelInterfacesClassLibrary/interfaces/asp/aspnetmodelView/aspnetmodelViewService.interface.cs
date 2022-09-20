using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView {
    public interface IAspnetmodelViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IAspnetmodelView rw, string nvNm);
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


        Task<IList<IAspnetmodelView>> getall();
        Task<IaspnetmodelViewPage> getwithfilter(IAspnetmodelViewFilter filter);
        Task<IAspnetmodelView> getone(
        System.Int32 ModelPk 
        );
        Task<IaspnetmodelViewPage> getmanybyrepprim(IAspnetmodelViewFilter filter);

        Task<IAspnetmodelView> updateone(IAspnetmodelView item);
        Task<IAspnetmodelView> addone(IAspnetmodelView item);
        Task<IAspnetmodelView> deleteone(System.Int32 ModelPk );
        IAspnetmodelViewNotify CopyToModelNotify(IAspnetmodelView  src, IAspnetmodelViewNotify dest = null);
        IAspnetmodelView CopyToModel(IAspnetmodelView  src, IAspnetmodelView dest = null);
        IAspnetmodelViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IAspnetmodelView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IAspnetmodelView r);
        IAspnetmodelViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IAspnetmodelViewFilter dest);
        IAspnetmodelViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IAspnetmodelViewFilter dest);
    }
}

