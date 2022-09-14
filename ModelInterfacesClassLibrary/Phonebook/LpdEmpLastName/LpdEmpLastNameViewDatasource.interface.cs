using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpLastName {
    public interface ILpdEmpLastNameViewDatasource: IViewModelDataSourceInterface
    {
        ILpdEmpLastNameView Values2Interface();
        Task<IList<ILpdEmpLastNameView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILpdEmpLastNameView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILpdEmpLastNameView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

