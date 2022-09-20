using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView {
    public interface IAspnetroleViewDatasource: IViewModelDataSourceInterface
    {
        IAspnetroleView Values2Interface();
        Task<IList<IAspnetroleView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IAspnetroleView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IAspnetroleView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

