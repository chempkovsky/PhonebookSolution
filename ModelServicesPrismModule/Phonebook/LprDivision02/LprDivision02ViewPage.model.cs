using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprDivision02;

namespace ModelServicesPrismModule.Phonebook.LprDivision02 {
    public class LprDivision02ViewPage: ILprDivision02ViewPage
    {
        public LprDivision02ViewPage() {}

        [JsonConstructorAttribute]
        public LprDivision02ViewPage(IList<LprDivision02View> items) 
        {
            this.items = new List<ILprDivision02View>(items);
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
        public IList<ILprDivision02View> items { get; set; }
    }
}

