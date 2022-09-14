using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LpdDivision;

namespace ModelServicesPrismModule.Phonebook.LpdDivision {
    public class LpdDivisionViewFilter: ILpdDivisionViewFilter 
    {
        public IList<System.Int32>  DivisionNameId { get; set; }
        public IList< string > divisionNameIdOprtr { get; set; }
        public IList<System.String>  DivisionName { get; set; }
        public IList< string > divisionNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

