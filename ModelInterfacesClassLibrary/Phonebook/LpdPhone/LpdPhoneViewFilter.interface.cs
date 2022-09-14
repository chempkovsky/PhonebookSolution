using System.Collections.Generic;

namespace ModelInterfacesClassLibrary.Phonebook.LpdPhone {
    public interface ILpdPhoneViewFilter
    {
        IList<System.Int32>  LpdPhoneId { get; set; }
        IList< string > lpdPhoneIdOprtr { get; set; }
        IList<System.String>  Phone { get; set; }
        IList< string > phoneOprtr { get; set; }
        IList< string > orderby { get; set; }
        int? page { get; set; }
        int? pagesize { get; set; }
    }
}

