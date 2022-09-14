using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise {
    public interface IPhbkEnterpriseViewFilter
    {
        IList<System.Int32>  EntrprsId { get; set; }
        IList< string > entrprsIdOprtr { get; set; }
        IList<System.String>  EntrprsName { get; set; }
        IList< string > entrprsNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

