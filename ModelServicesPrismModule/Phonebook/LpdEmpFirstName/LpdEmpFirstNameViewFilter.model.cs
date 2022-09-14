using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpFirstName {
    public class LpdEmpFirstNameViewFilter: ILpdEmpFirstNameViewFilter 
    {
        public IList<System.Int32>  EmpFirstNameId { get; set; }
        public IList< string > empFirstNameIdOprtr { get; set; }
        public IList<System.String>  EmpFirstName { get; set; }
        public IList< string > empFirstNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

