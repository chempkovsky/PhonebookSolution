using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpSecondName {
    public class LpdEmpSecondNameViewPage: ILpdEmpSecondNameViewPage
    {
        public LpdEmpSecondNameViewPage() {}

        [JsonConstructorAttribute]
        public LpdEmpSecondNameViewPage(IList<LpdEmpSecondNameView> items) 
        {
            this.items = new List<ILpdEmpSecondNameView>(items);
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
        public IList<ILpdEmpSecondNameView> items { get; set; }
    }
}

