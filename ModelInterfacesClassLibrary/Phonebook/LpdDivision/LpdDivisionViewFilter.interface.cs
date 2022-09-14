using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LpdDivision {
    public interface ILpdDivisionViewFilter
    {
        IList<System.Int32>  DivisionNameId { get; set; }
        IList< string > divisionNameIdOprtr { get; set; }
        IList<System.String>  DivisionName { get; set; }
        IList< string > divisionNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

