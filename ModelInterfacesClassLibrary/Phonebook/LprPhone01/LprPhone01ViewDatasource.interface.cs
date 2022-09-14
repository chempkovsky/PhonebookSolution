using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone01 {
    public interface ILprPhone01ViewDatasource: IViewModelDataSourceInterface
    {
        ILprPhone01View Values2Interface();
        Task<IList<ILprPhone01View>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILprPhone01View data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILprPhone01View>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

