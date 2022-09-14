using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName {
    public interface ILpdEmpSecondNameViewFilter
    {
        IList<System.Int32>  EmpSecondNameId { get; set; }
        IList< string > empSecondNameIdOprtr { get; set; }
        IList<System.String>  EmpSecondName { get; set; }
        IList< string > empSecondNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

