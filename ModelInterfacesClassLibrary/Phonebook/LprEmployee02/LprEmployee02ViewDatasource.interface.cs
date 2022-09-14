using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprEmployee02 {
    public interface ILprEmployee02ViewDatasource: IViewModelDataSourceInterface
    {
        ILprEmployee02View Values2Interface();
        Task<IList<ILprEmployee02View>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILprEmployee02View data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILprEmployee02View>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

