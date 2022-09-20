using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView {
    public interface IAspnetuserrolesViewDatasource: IViewModelDataSourceInterface
    {
        IAspnetuserrolesView Values2Interface();
        Task<IList<IAspnetuserrolesView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IAspnetuserrolesView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IAspnetuserrolesView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

