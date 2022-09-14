using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone02 {
    public interface ILprPhone02ViewDatasource: IViewModelDataSourceInterface
    {
        ILprPhone02View Values2Interface();
        Task<IList<ILprPhone02View>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILprPhone02View data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILprPhone02View>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

