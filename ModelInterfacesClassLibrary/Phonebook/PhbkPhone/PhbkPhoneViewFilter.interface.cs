using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkPhone {
    public interface IPhbkPhoneViewFilter
    {
        IList<System.Int32>  PhoneId { get; set; }
        IList< string > phoneIdOprtr { get; set; }
        IList<System.String>  Phone { get; set; }
        IList< string > phoneOprtr { get; set; }
        IList<System.Int32>  PhoneTypeIdRef { get; set; }
        IList< string > phoneTypeIdRefOprtr { get; set; }
        IList<System.Int32>  EmployeeIdRef { get; set; }
        IList< string > employeeIdRefOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

