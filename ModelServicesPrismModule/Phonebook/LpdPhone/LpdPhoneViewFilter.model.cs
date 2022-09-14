using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LpdPhone;

namespace ModelServicesPrismModule.Phonebook.LpdPhone {
    public class LpdPhoneViewFilter: ILpdPhoneViewFilter 
    {
        public IList<System.Int32>  LpdPhoneId { get; set; }
        public IList< string > lpdPhoneIdOprtr { get; set; }
        public IList<System.String>  Phone { get; set; }
        public IList< string > phoneOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

