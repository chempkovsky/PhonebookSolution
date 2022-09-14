using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName {
    public interface ILpdEmpFirstNameViewDatasource: IViewModelDataSourceInterface
    {
        ILpdEmpFirstNameView Values2Interface();
        Task<IList<ILpdEmpFirstNameView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILpdEmpFirstNameView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILpdEmpFirstNameView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

