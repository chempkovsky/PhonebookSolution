using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdDivision;

namespace ModelServicesPrismModule.Phonebook.LpdDivision {
    public class LpdDivisionViewPage: ILpdDivisionViewPage
    {
        public LpdDivisionViewPage() {}

        [JsonConstructorAttribute]
        public LpdDivisionViewPage(IList<LpdDivisionView> items) 
        {
            this.items = new List<ILpdDivisionView>(items);
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
        public IList<ILpdDivisionView> items { get; set; }
    }
}

