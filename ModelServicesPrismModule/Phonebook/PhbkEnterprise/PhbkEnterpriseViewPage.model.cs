using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;

namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise {
    public class PhbkEnterpriseViewPage: IPhbkEnterpriseViewPage
    {
        public PhbkEnterpriseViewPage() {}

        [JsonConstructorAttribute]
        public PhbkEnterpriseViewPage(IList<PhbkEnterpriseView> items) 
        {
            this.items = new List<IPhbkEnterpriseView>(items);
        }

        [JsonProperty(PropertyName = "page")]
        public int page { get; set; }

        [JsonProperty(PropertyName = "pagesize")]
        public int pagesize { get; set; }

        [JsonProperty(PropertyName = "pagecount")]
        public int pagecount { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int total { get; set; }

        [JsonProperty(PropertyName = "items")]
        public IList<IPhbkEnterpriseView> items { get; set; }
    }
}

