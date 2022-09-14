using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LprDivision01 {
    public interface ILprDivision01ViewFilter
    {
        IList<System.Int32>  DivisionId { get; set; }
        IList< string > divisionIdOprtr { get; set; }
        IList<System.Int32>  DivisionNameIdRef { get; set; }
        IList< string > divisionNameIdRefOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

