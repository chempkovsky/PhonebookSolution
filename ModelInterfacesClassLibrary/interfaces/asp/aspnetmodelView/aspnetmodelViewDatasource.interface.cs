using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView {
    public interface IAspnetmodelViewDatasource: IViewModelDataSourceInterface
    {
        IAspnetmodelView Values2Interface();
        Task<IList<IAspnetmodelView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IAspnetmodelView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IAspnetmodelView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

