using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone04 {
    public interface ILprPhone04ViewFilter
    {
        IList<System.Int32>  PhoneId { get; set; }
        IList< string > phoneIdOprtr { get; set; }
        IList<System.Int32>  LpdPhoneIdRef { get; set; }
        IList< string > lpdPhoneIdRefOprtr { get; set; }
        IList<System.Int32>  EmployeeIdRef { get; set; }
        IList< string > employeeIdRefOprtr { get; set; }
        IList<System.Int32>  PhoneTypeIdRef { get; set; }
        IList< string > phoneTypeIdRefOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

