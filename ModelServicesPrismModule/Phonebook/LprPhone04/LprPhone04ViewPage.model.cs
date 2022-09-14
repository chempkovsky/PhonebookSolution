using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone04;

namespace ModelServicesPrismModule.Phonebook.LprPhone04 {
    public class LprPhone04ViewPage: ILprPhone04ViewPage
    {
        public LprPhone04ViewPage() {}

        [JsonConstructorAttribute]
        public LprPhone04ViewPage(IList<LprPhone04View> items) 
        {
            this.items = new List<ILprPhone04View>(items);
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
        public IList<ILprPhone04View> items { get; set; }
    }
}

