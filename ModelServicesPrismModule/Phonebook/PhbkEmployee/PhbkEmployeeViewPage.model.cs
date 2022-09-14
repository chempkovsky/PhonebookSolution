using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee {
    public class PhbkEmployeeViewPage: IPhbkEmployeeViewPage
    {
        public PhbkEmployeeViewPage() {}

        [JsonConstructorAttribute]
        public PhbkEmployeeViewPage(IList<PhbkEmployeeView> items) 
        {
            this.items = new List<IPhbkEmployeeView>(items);
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
        public IList<IPhbkEmployeeView> items { get; set; }
    }
}

