using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee {
    public class PhbkEmployeeViewFilter: IPhbkEmployeeViewFilter 
    {
        public IList<System.Int32>  EmployeeId { get; set; }
        public IList< string > employeeIdOprtr { get; set; }
        public IList<System.String>  EmpFirstName { get; set; }
        public IList< string > empFirstNameOprtr { get; set; }
        public IList<System.String>  EmpLastName { get; set; }
        public IList< string > empLastNameOprtr { get; set; }
        public IList<System.Int32>  DivisionIdRef { get; set; }
        public IList< string > divisionIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

