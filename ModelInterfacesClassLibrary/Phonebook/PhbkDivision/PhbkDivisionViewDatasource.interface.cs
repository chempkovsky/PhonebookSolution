using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkDivision {
    public interface IPhbkDivisionViewDatasource: IViewModelDataSourceInterface
    {
        IPhbkDivisionView Values2Interface();
        Task<IList<IPhbkDivisionView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IPhbkDivisionView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IPhbkDivisionView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

