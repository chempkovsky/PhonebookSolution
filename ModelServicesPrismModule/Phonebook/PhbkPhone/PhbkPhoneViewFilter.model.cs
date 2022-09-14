using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;

namespace ModelServicesPrismModule.Phonebook.PhbkPhone {
    public class PhbkPhoneViewFilter: IPhbkPhoneViewFilter 
    {
        public IList<System.Int32>  PhoneId { get; set; }
        public IList< string > phoneIdOprtr { get; set; }
        public IList<System.String>  Phone { get; set; }
        public IList< string > phoneOprtr { get; set; }
        public IList<System.Int32>  PhoneTypeIdRef { get; set; }
        public IList< string > phoneTypeIdRefOprtr { get; set; }
        public IList<System.Int32>  EmployeeIdRef { get; set; }
        public IList< string > employeeIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

