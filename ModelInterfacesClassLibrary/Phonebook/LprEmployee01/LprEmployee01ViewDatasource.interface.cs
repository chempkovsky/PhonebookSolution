using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprEmployee01 {
    public interface ILprEmployee01ViewDatasource: IViewModelDataSourceInterface
    {
        ILprEmployee01View Values2Interface();
        Task<IList<ILprEmployee01View>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILprEmployee01View data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILprEmployee01View>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

