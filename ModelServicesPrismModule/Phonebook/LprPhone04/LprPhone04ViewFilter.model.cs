using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LprPhone04;

namespace ModelServicesPrismModule.Phonebook.LprPhone04 {
    public class LprPhone04ViewFilter: ILprPhone04ViewFilter 
    {
        public IList<System.Int32>  PhoneId { get; set; }
        public IList< string > phoneIdOprtr { get; set; }
        public IList<System.Int32>  LpdPhoneIdRef { get; set; }
        public IList< string > lpdPhoneIdRefOprtr { get; set; }
        public IList<System.Int32>  EmployeeIdRef { get; set; }
        public IList< string > employeeIdRefOprtr { get; set; }
        public IList<System.Int32>  PhoneTypeIdRef { get; set; }
        public IList< string > phoneTypeIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

