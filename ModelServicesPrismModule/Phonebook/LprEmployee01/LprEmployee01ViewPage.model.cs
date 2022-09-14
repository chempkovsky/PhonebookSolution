using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee01;

namespace ModelServicesPrismModule.Phonebook.LprEmployee01 {
    public class LprEmployee01ViewPage: ILprEmployee01ViewPage
    {
        public LprEmployee01ViewPage() {}

        [JsonConstructorAttribute]
        public LprEmployee01ViewPage(IList<LprEmployee01View> items) 
        {
            this.items = new List<ILprEmployee01View>(items);
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
        public IList<ILprEmployee01View> items { get; set; }
    }
}

