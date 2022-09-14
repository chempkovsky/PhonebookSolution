using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LprPhone01;

namespace ModelServicesPrismModule.Phonebook.LprPhone01 {
    public class LprPhone01ViewFilter: ILprPhone01ViewFilter 
    {
        public IList<System.Int32>  PhoneId { get; set; }
        public IList< string > phoneIdOprtr { get; set; }
        public IList<System.Int32>  LpdPhoneIdRef { get; set; }
        public IList< string > lpdPhoneIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

