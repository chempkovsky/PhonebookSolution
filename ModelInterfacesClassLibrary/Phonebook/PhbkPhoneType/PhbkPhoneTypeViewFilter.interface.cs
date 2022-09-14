using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType {
    public interface IPhbkPhoneTypeViewFilter
    {
        IList<System.Int32>  PhoneTypeId { get; set; }
        IList< string > phoneTypeIdOprtr { get; set; }
        IList<System.String>  PhoneTypeName { get; set; }
        IList< string > phoneTypeNameOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

