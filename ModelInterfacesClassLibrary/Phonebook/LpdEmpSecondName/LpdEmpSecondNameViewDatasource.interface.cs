using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName {
    public interface ILpdEmpSecondNameViewDatasource: IViewModelDataSourceInterface
    {
        ILpdEmpSecondNameView Values2Interface();
        Task<IList<ILpdEmpSecondNameView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILpdEmpSecondNameView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILpdEmpSecondNameView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

