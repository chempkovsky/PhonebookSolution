using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone04 {
    public interface ILprPhone04ViewDatasource: IViewModelDataSourceInterface
    {
        ILprPhone04View Values2Interface();
        Task<IList<ILprPhone04View>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILprPhone04View data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILprPhone04View>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

