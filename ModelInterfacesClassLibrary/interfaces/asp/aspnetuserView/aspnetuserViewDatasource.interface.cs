using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView {
    public interface IAspnetuserViewDatasource: IViewModelDataSourceInterface
    {
        IAspnetuserView Values2Interface();
        Task<IList<IAspnetuserView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IAspnetuserView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IAspnetuserView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

