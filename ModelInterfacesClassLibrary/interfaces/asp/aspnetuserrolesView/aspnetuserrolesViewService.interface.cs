using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView {
    public interface IAspnetuserrolesViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(IAspnetuserrolesView rw, string nvNm);
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


        Task<IList<IAspnetuserrolesView>> getall();
        Task<IaspnetuserrolesViewPage> getwithfilter(IAspnetuserrolesViewFilter filter);
        Task<IAspnetuserrolesView> getone(
        System.String UserId 
        , System.String RoleId 
        );
        Task<IaspnetuserrolesViewPage> getmanybyrepprim(IAspnetuserrolesViewFilter filter);

        Task<IAspnetuserrolesView> updateone(IAspnetuserrolesView item);
        Task<IAspnetuserrolesView> addone(IAspnetuserrolesView item);
        Task<IAspnetuserrolesView> deleteone(System.String UserId , System.String RoleId );
        IAspnetuserrolesViewNotify CopyToModelNotify(IAspnetuserrolesView  src, IAspnetuserrolesViewNotify dest = null);
        IAspnetuserrolesView CopyToModel(IAspnetuserrolesView  src, IAspnetuserrolesView dest = null);
        IAspnetuserrolesViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(IAspnetuserrolesView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(IAspnetuserrolesView r);
        IAspnetuserrolesViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, IAspnetuserrolesViewFilter dest);
        IAspnetuserrolesViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, IAspnetuserrolesViewFilter dest);
    }
}

