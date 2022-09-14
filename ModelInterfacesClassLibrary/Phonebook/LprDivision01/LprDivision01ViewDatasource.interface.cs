using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprDivision01 {
    public interface ILprDivision01ViewDatasource: IViewModelDataSourceInterface
    {
        ILprDivision01View Values2Interface();
        Task<IList<ILprDivision01View>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILprDivision01View data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILprDivision01View>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

