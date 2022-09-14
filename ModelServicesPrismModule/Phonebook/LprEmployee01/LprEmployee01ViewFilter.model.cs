using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee01;

namespace ModelServicesPrismModule.Phonebook.LprEmployee01 {
    public class LprEmployee01ViewFilter: ILprEmployee01ViewFilter 
    {
        public IList<System.Int32>  EmployeeId { get; set; }
        public IList< string > employeeIdOprtr { get; set; }
        public IList<System.Int32>  EmpLastNameIdRef { get; set; }
        public IList< string > empLastNameIdRefOprtr { get; set; }
        public IList<System.Int32>  EmpFirstNameIdRef { get; set; }
        public IList< string > empFirstNameIdRefOprtr { get; set; }
        public IList<System.Int32>  EmpSecondNameIdRef { get; set; }
        public IList< string > empSecondNameIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

