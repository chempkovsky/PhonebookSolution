using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee02;

namespace ModelServicesPrismModule.Phonebook.LprEmployee02 {
    public class LprEmployee02ViewPage: ILprEmployee02ViewPage
    {
        public LprEmployee02ViewPage() {}

        [JsonConstructorAttribute]
        public LprEmployee02ViewPage(IList<LprEmployee02View> items) 
        {
            this.items = new List<ILprEmployee02View>(items);
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
        public IList<ILprEmployee02View> items { get; set; }
    }
}

