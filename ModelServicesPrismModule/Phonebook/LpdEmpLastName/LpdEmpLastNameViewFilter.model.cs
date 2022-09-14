using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpLastName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpLastName {
    public class LpdEmpLastNameViewFilter: ILpdEmpLastNameViewFilter 
    {
        public IList<System.Int32>  EmpLastNameId { get; set; }
        public IList< string > empLastNameIdOprtr { get; set; }
        public IList<System.String>  EmpLastName { get; set; }
        public IList< string > empLastNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

