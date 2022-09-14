using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone01;

namespace ModelServicesPrismModule.Phonebook.LprPhone01 {
    public class LprPhone01ViewPage: ILprPhone01ViewPage
    {
        public LprPhone01ViewPage() {}

        [JsonConstructorAttribute]
        public LprPhone01ViewPage(IList<LprPhone01View> items) 
        {
            this.items = new List<ILprPhone01View>(items);
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
        public IList<ILprPhone01View> items { get; set; }
    }
}

