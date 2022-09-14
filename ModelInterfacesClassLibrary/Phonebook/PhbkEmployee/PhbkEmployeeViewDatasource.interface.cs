using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkEmployee {
    public interface IPhbkEmployeeViewDatasource: IViewModelDataSourceInterface
    {
        IPhbkEmployeeView Values2Interface();
        Task<IList<IPhbkEmployeeView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IPhbkEmployeeView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IPhbkEmployeeView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

