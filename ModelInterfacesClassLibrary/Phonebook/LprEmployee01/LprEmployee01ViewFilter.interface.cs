using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LprEmployee01 {
    public interface ILprEmployee01ViewFilter
    {
        IList<System.Int32>  EmployeeId { get; set; }
        IList< string > employeeIdOprtr { get; set; }
        IList<System.Int32>  EmpLastNameIdRef { get; set; }
        IList< string > empLastNameIdRefOprtr { get; set; }
        IList<System.Int32>  EmpFirstNameIdRef { get; set; }
        IList< string > empFirstNameIdRefOprtr { get; set; }
        IList<System.Int32>  EmpSecondNameIdRef { get; set; }
        IList< string > empSecondNameIdRefOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

