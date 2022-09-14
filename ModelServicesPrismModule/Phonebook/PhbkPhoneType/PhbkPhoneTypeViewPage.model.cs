using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType;

namespace ModelServicesPrismModule.Phonebook.PhbkPhoneType {
    public class PhbkPhoneTypeViewPage: IPhbkPhoneTypeViewPage
    {
        public PhbkPhoneTypeViewPage() {}

        [JsonConstructorAttribute]
        public PhbkPhoneTypeViewPage(IList<PhbkPhoneTypeView> items) 
        {
            this.items = new List<IPhbkPhoneTypeView>(items);
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
        public IList<IPhbkPhoneTypeView> items { get; set; }
    }
}

