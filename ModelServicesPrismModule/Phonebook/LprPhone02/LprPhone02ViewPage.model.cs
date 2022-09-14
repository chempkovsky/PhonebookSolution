using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone02;

namespace ModelServicesPrismModule.Phonebook.LprPhone02 {
    public class LprPhone02ViewPage: ILprPhone02ViewPage
    {
        public LprPhone02ViewPage() {}

        [JsonConstructorAttribute]
        public LprPhone02ViewPage(IList<LprPhone02View> items) 
        {
            this.items = new List<ILprPhone02View>(items);
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
        public IList<ILprPhone02View> items { get; set; }
    }
}

