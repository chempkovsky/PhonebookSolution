using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprDivision02 {
    public interface ILprDivision02ViewDatasource: IViewModelDataSourceInterface
    {
        ILprDivision02View Values2Interface();
        Task<IList<ILprDivision02View>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILprDivision02View data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILprDivision02View>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

