using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName {
    public interface ILpdEmpSecondNameViewService
    {
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm();
        Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm();
        Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILpdEmpSecondNameView rw, string nvNm);
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


        Task<IList<ILpdEmpSecondNameView>> getall();
        Task<ILpdEmpSecondNameViewPage> getwithfilter(ILpdEmpSecondNameViewFilter filter);
        Task<ILpdEmpSecondNameView> getone(
        System.Int32 EmpSecondNameId 
        );
        Task<ILpdEmpSecondNameViewPage> getmanybyrepprim(ILpdEmpSecondNameViewFilter filter);

        Task<ILpdEmpSecondNameView> getonebyLpdEmpSecondNameUK(
        System.String EmpSecondName 
        );
        Task<ILpdEmpSecondNameViewPage> getmanybyrepunqLpdEmpSecondNameUK(ILpdEmpSecondNameViewFilter filter);

        Task<ILpdEmpSecondNameView> updateone(ILpdEmpSecondNameView item);
        Task<ILpdEmpSecondNameView> addone(ILpdEmpSecondNameView item);
        Task<ILpdEmpSecondNameView> deleteone(System.Int32 EmpSecondNameId );
        ILpdEmpSecondNameViewNotify CopyToModelNotify(ILpdEmpSecondNameView  src, ILpdEmpSecondNameViewNotify dest = null);
        ILpdEmpSecondNameView CopyToModel(ILpdEmpSecondNameView  src, ILpdEmpSecondNameView dest = null);
        ILpdEmpSecondNameViewFilter GetFilter();
        IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILpdEmpSecondNameView r);
        IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILpdEmpSecondNameView r);
        ILpdEmpSecondNameViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILpdEmpSecondNameViewFilter dest);
        ILpdEmpSecondNameViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILpdEmpSecondNameViewFilter dest);
    }
}

