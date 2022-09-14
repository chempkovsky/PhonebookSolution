using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone02 {
    public interface ILprPhone02ViewFilter
    {
        IList<System.Int32>  PhoneId { get; set; }
        IList< string > phoneIdOprtr { get; set; }
        IList<System.Int32>  LpdPhoneIdRef { get; set; }
        IList< string > lpdPhoneIdRefOprtr { get; set; }
        IList<System.Int32>  EmployeeIdRef { get; set; }
        IList< string > employeeIdRefOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

