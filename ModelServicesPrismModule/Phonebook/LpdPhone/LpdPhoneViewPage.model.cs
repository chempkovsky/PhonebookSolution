using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdPhone;

namespace ModelServicesPrismModule.Phonebook.LpdPhone {
    public class LpdPhoneViewPage: ILpdPhoneViewPage
    {
        public LpdPhoneViewPage() {}

        [JsonConstructorAttribute]
        public LpdPhoneViewPage(IList<LpdPhoneView> items) 
        {
            this.items = new List<ILpdPhoneView>(items);
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
        public IList<ILpdPhoneView> items { get; set; }
    }
}

