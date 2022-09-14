using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType;

namespace ModelServicesPrismModule.Phonebook.PhbkPhoneType {
    public class PhbkPhoneTypeViewFilter: IPhbkPhoneTypeViewFilter 
    {
        public IList<System.Int32>  PhoneTypeId { get; set; }
        public IList< string > phoneTypeIdOprtr { get; set; }
        public IList<System.String>  PhoneTypeName { get; set; }
        public IList< string > phoneTypeNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

