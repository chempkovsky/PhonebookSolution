using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdPhone {
    public interface ILpdPhoneViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILpdPhoneView rw, string nvNm);
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


        Task<IList<ILpdPhoneView>> getall();
        Task<ILpdPhoneViewPage> getwithfilter(ILpdPhoneViewFilter filter);
        Task<ILpdPhoneView> getone(
        System.Int32 LpdPhoneId 
        );
        Task<ILpdPhoneViewPage> getmanybyrepprim(ILpdPhoneViewFilter filter);

        Task<ILpdPhoneView> getonebyLpdPhoneUK(
        System.String Phone 
        );
        Task<ILpdPhoneViewPage> getmanybyrepunqLpdPhoneUK(ILpdPhoneViewFilter filter);

        Task<ILpdPhoneView> updateone(ILpdPhoneView item);
        Task<ILpdPhoneView> addone(ILpdPhoneView item);
        Task<ILpdPhoneView> deleteone(System.Int32 LpdPhoneId );
        ILpdPhoneViewNotify CopyToModelNotify(ILpdPhoneView  src, ILpdPhoneViewNotify dest = null);
        ILpdPhoneView CopyToModel(ILpdPhoneView  src, ILpdPhoneView dest = null);
        ILpdPhoneViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILpdPhoneView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILpdPhoneView r);
        ILpdPhoneViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILpdPhoneViewFilter dest);
        ILpdPhoneViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILpdPhoneViewFilter dest);
    }
}

