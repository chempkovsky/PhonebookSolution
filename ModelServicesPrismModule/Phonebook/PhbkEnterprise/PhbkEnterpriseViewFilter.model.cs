using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;

namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise {
    public class PhbkEnterpriseViewFilter: IPhbkEnterpriseViewFilter 
    {
        public IList<System.Int32>  EntrprsId { get; set; }
        public IList< string > entrprsIdOprtr { get; set; }
        public IList<System.String>  EntrprsName { get; set; }
        public IList< string > entrprsNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

