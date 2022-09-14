using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LprDivision02;

namespace ModelServicesPrismModule.Phonebook.LprDivision02 {
    public class LprDivision02ViewFilter: ILprDivision02ViewFilter 
    {
        public IList<System.Int32>  DivisionId { get; set; }
        public IList< string > divisionIdOprtr { get; set; }
        public IList<System.Int32>  EntrprsIdRef { get; set; }
        public IList< string > entrprsIdRefOprtr { get; set; }
        public IList<System.Int32>  DivisionNameIdRef { get; set; }
        public IList< string > divisionNameIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

