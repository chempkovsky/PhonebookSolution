using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserpermsView {
    public interface IAspnetuserpermsViewDatasource: IViewModelDataSourceInterface
    {
        IAspnetuserpermsView Values2Interface();
        Task<IList<IAspnetuserpermsView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IAspnetuserpermsView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IAspnetuserpermsView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

