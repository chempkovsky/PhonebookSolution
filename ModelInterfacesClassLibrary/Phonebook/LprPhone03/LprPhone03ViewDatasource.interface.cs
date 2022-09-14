using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone03 {
    public interface ILprPhone03ViewDatasource: IViewModelDataSourceInterface
    {
        ILprPhone03View Values2Interface();
        Task<IList<ILprPhone03View>> GetClActionByCurrDirMstrs();
        bool Interface2Values(ILprPhone03View data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<ILprPhone03View>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

