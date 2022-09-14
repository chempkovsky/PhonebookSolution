using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkDivision {
    public interface IPhbkDivisionViewFilter
    {
        IList<System.Int32>  DivisionId { get; set; }
        IList< string > divisionIdOprtr { get; set; }
        IList<System.String>  DivisionName { get; set; }
        IList< string > divisionNameOprtr { get; set; }
        IList<System.Int32>  EntrprsIdRef { get; set; }
        IList< string > entrprsIdRefOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

