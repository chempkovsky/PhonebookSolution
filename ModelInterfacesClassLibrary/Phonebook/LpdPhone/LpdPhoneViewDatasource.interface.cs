using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdPhone {
    public interface ILpdPhoneViewDatasource: IViewModelDataSourceInterface
    {
        ILpdPhoneView Values2Interface();
        Task<IList<ILpdPhoneView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILpdPhoneView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILpdPhoneView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

