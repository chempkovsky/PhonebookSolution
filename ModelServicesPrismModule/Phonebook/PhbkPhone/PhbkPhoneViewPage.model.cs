using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;

namespace ModelServicesPrismModule.Phonebook.PhbkPhone {
    public class PhbkPhoneViewPage: IPhbkPhoneViewPage
    {
        public PhbkPhoneViewPage() {}

        [JsonConstructorAttribute]
        public PhbkPhoneViewPage(IList<PhbkPhoneView> items) 
        {
            this.items = new List<IPhbkPhoneView>(items);
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
        public IList<IPhbkPhoneView> items { get; set; }
    }
}

