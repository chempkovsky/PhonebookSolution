using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;

namespace ModelServicesPrismModule.Phonebook.PhbkDivision {
    public class PhbkDivisionViewPage: IPhbkDivisionViewPage
    {
        public PhbkDivisionViewPage() {}

        [JsonConstructorAttribute]
        public PhbkDivisionViewPage(IList<PhbkDivisionView> items) 
        {
            this.items = new List<IPhbkDivisionView>(items);
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
        public IList<IPhbkDivisionView> items { get; set; }
    }
}

