using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkEmployee {
    public interface IPhbkEmployeeViewFilter
    {
        IList<System.Int32>  EmployeeId { get; set; }
        IList< string > employeeIdOprtr { get; set; }
        IList<System.String>  EmpFirstName { get; set; }
        IList< string > empFirstNameOprtr { get; set; }
        IList<System.String>  EmpLastName { get; set; }
        IList< string > empLastNameOprtr { get; set; }
        IList<System.Int32>  DivisionIdRef { get; set; }
        IList< string > divisionIdRefOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

