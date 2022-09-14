using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpSecondName {
    public class LpdEmpSecondNameViewFilter: ILpdEmpSecondNameViewFilter 
    {
        public IList<System.Int32>  EmpSecondNameId { get; set; }
        public IList< string > empSecondNameIdOprtr { get; set; }
        public IList<System.String>  EmpSecondName { get; set; }
        public IList< string > empSecondNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

