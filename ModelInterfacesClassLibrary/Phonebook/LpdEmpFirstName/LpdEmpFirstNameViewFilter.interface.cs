using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName {
    public interface ILpdEmpFirstNameViewFilter
    {
        IList<System.Int32>  EmpFirstNameId { get; set; }
        IList< string > empFirstNameIdOprtr { get; set; }
        IList<System.String>  EmpFirstName { get; set; }
        IList< string > empFirstNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

