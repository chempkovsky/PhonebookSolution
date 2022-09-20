using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetusermaskView {
    public interface IAspnetusermaskViewDatasource: IViewModelDataSourceInterface
    {
        IAspnetusermaskView Values2Interface();
        Task<IList<IAspnetusermaskView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IAspnetusermaskView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IAspnetusermaskView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

