using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpLastName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpLastName {
    public class LpdEmpLastNameViewPage: ILpdEmpLastNameViewPage
    {
        public LpdEmpLastNameViewPage() {}

        [JsonConstructorAttribute]
        public LpdEmpLastNameViewPage(IList<LpdEmpLastNameView> items) 
        {
            this.items = new List<ILpdEmpLastNameView>(items);
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
        public IList<ILpdEmpLastNameView> items { get; set; }
    }
}

