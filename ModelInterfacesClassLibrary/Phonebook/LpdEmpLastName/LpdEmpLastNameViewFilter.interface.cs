using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpLastName {
    public interface ILpdEmpLastNameViewFilter
    {
        IList<System.Int32>  EmpLastNameId { get; set; }
        IList< string > empLastNameIdOprtr { get; set; }
        IList<System.String>  EmpLastName { get; set; }
        IList< string > empLastNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

