using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CommonInterfacesClassLibrary.Interfaces;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise {
    public interface IPhbkEnterpriseViewDatasource: IViewModelDataSourceInterface
    {
        IPhbkEnterpriseView Values2Interface();
        Task<IList<IPhbkEnterpriseView>> GetClActionByCurrDirMstrs();
        bool Interface2Values(IPhbkEnterpriseView data, bool doNotify = true);
        IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs();
        Task<IList<IPhbkEnterpriseView>> GetClActionByFldFilter(string fldName, object fldVal);
    }
}

