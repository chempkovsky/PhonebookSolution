using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprDivision01;

namespace ModelServicesPrismModule.Phonebook.LprDivision01 {
    public class LprDivision01ViewPage: ILprDivision01ViewPage
    {
        public LprDivision01ViewPage() {}

        [JsonConstructorAttribute]
        public LprDivision01ViewPage(IList<LprDivision01View> items) 
        {
            this.items = new List<ILprDivision01View>(items);
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
        public IList<ILprDivision01View> items { get; set; }
    }
}

