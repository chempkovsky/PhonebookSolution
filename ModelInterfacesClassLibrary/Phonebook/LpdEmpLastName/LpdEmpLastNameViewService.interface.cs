using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpLastName {
    public interface ILpdEmpLastNameViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILpdEmpLastNameView rw, string nvNm);
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


        Task<IList<ILpdEmpLastNameView>> getall();
        Task<ILpdEmpLastNameViewPage> getwithfilter(ILpdEmpLastNameViewFilter filter);
        Task<ILpdEmpLastNameView> getone(
        System.Int32 EmpLastNameId 
        );
        Task<ILpdEmpLastNameViewPage> getmanybyrepprim(ILpdEmpLastNameViewFilter filter);

        Task<ILpdEmpLastNameView> getonebyLpdEmpLastNameUK(
        System.String EmpLastName 
        );
        Task<ILpdEmpLastNameViewPage> getmanybyrepunqLpdEmpLastNameUK(ILpdEmpLastNameViewFilter filter);

        Task<ILpdEmpLastNameView> updateone(ILpdEmpLastNameView item);
        Task<ILpdEmpLastNameView> addone(ILpdEmpLastNameView item);
        Task<ILpdEmpLastNameView> deleteone(System.Int32 EmpLastNameId );
        ILpdEmpLastNameViewNotify CopyToModelNotify(ILpdEmpLastNameView  src, ILpdEmpLastNameViewNotify dest = null);
        ILpdEmpLastNameView CopyToModel(ILpdEmpLastNameView  src, ILpdEmpLastNameView dest = null);
        ILpdEmpLastNameViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILpdEmpLastNameView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILpdEmpLastNameView r);
        ILpdEmpLastNameViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILpdEmpLastNameViewFilter dest);
        ILpdEmpLastNameViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILpdEmpLastNameViewFilter dest);
    }
}

