using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;

namespace ModelServicesPrismModule.Phonebook.PhbkDivision {
    public class PhbkDivisionViewFilter: IPhbkDivisionViewFilter 
    {
        public IList<System.Int32>  DivisionId { get; set; }
        public IList< string > divisionIdOprtr { get; set; }
        public IList<System.String>  DivisionName { get; set; }
        public IList< string > divisionNameOprtr { get; set; }
        public IList<System.Int32>  EntrprsIdRef { get; set; }
        public IList< string > entrprsIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

