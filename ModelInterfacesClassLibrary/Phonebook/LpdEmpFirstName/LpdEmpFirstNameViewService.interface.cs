using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName {
    public interface ILpdEmpFirstNameViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILpdEmpFirstNameView rw, string nvNm);
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


        Task<IList<ILpdEmpFirstNameView>> getall();
        Task<ILpdEmpFirstNameViewPage> getwithfilter(ILpdEmpFirstNameViewFilter filter);
        Task<ILpdEmpFirstNameView> getone(
        System.Int32 EmpFirstNameId 
        );
        Task<ILpdEmpFirstNameViewPage> getmanybyrepprim(ILpdEmpFirstNameViewFilter filter);

        Task<ILpdEmpFirstNameView> getonebyLpdEmpFirstNameUK(
        System.String EmpFirstName 
        );
        Task<ILpdEmpFirstNameViewPage> getmanybyrepunqLpdEmpFirstNameUK(ILpdEmpFirstNameViewFilter filter);

        Task<ILpdEmpFirstNameView> updateone(ILpdEmpFirstNameView item);
        Task<ILpdEmpFirstNameView> addone(ILpdEmpFirstNameView item);
        Task<ILpdEmpFirstNameView> deleteone(System.Int32 EmpFirstNameId );
        ILpdEmpFirstNameViewNotify CopyToModelNotify(ILpdEmpFirstNameView  src, ILpdEmpFirstNameViewNotify dest = null);
        ILpdEmpFirstNameView CopyToModel(ILpdEmpFirstNameView  src, ILpdEmpFirstNameView dest = null);
        ILpdEmpFirstNameViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILpdEmpFirstNameView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILpdEmpFirstNameView r);
        ILpdEmpFirstNameViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILpdEmpFirstNameViewFilter dest);
        ILpdEmpFirstNameViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILpdEmpFirstNameViewFilter dest);
    }
}

