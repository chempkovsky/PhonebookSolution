using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpFirstName {
    public class LpdEmpFirstNameViewPage: ILpdEmpFirstNameViewPage
    {
        public LpdEmpFirstNameViewPage() {}

        [JsonConstructorAttribute]
        public LpdEmpFirstNameViewPage(IList<LpdEmpFirstNameView> items) 
        {
            this.items = new List<ILpdEmpFirstNameView>(items);
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
        public IList<ILpdEmpFirstNameView> items { get; set; }
    }
}

