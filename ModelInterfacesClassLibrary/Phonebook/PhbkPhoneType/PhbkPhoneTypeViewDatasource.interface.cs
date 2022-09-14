using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType {
    public interface IPhbkPhoneTypeViewDatasource: IViewModelDataSourceInterface
    {
        IPhbkPhoneTypeView Values2Interface();
        Task<IList<IPhbkPhoneTypeView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IPhbkPhoneTypeView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IPhbkPhoneTypeView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

