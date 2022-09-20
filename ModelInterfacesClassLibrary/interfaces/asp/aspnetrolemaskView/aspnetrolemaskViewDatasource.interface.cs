using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView {
    public interface IAspnetrolemaskViewDatasource: IViewModelDataSourceInterface
    {
        IAspnetrolemaskView Values2Interface();
        Task<IList<IAspnetrolemaskView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IAspnetrolemaskView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IAspnetrolemaskView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

