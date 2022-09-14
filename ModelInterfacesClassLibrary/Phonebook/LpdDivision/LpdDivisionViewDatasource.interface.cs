using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LpdDivision {
    public interface ILpdDivisionViewDatasource: IViewModelDataSourceInterface
    {
        ILpdDivisionView Values2Interface();
        Task<IList<ILpdDivisionView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILpdDivisionView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILpdDivisionView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

