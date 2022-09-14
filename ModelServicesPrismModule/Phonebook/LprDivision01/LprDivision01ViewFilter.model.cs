using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LprDivision01;

namespace ModelServicesPrismModule.Phonebook.LprDivision01 {
    public class LprDivision01ViewFilter: ILprDivision01ViewFilter 
    {
        public IList<System.Int32>  DivisionId { get; set; }
        public IList< string > divisionIdOprtr { get; set; }
        public IList<System.Int32>  DivisionNameIdRef { get; set; }
        public IList< string > divisionNameIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

