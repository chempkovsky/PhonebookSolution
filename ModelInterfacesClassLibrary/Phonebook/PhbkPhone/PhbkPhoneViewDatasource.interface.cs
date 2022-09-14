using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkPhone {
    public interface IPhbkPhoneViewDatasource: IViewModelDataSourceInterface
    {
        IPhbkPhoneView Values2Interface();
        Task<IList<IPhbkPhoneView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IPhbkPhoneView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IPhbkPhoneView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

