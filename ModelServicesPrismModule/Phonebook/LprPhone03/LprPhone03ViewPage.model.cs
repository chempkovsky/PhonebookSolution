using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone03;

namespace ModelServicesPrismModule.Phonebook.LprPhone03 {
    public class LprPhone03ViewPage: ILprPhone03ViewPage
    {
        public LprPhone03ViewPage() {}

        [JsonConstructorAttribute]
        public LprPhone03ViewPage(IList<LprPhone03View> items) 
        {
            this.items = new List<ILprPhone03View>(items);
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
        public IList<ILprPhone03View> items { get; set; }
    }
}

