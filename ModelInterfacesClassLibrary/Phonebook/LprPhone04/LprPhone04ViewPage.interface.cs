using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone04;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone04 {
    public interface ILprPhone04ViewPage
    {
        [JsonProperty(PropertyName = "page")]
        int page { get; set; }

        [JsonProperty(PropertyName = "pagesize")]
        int pagesize { get; set; }

        [JsonProperty(PropertyName = "pagecount")]
        int pagecount { get; set; }

        [JsonProperty(PropertyName = "total")]
        int total { get; set; }

        [JsonProperty(PropertyName = "items")]
        IList<ILprPhone04View> items { get; set; }
    }
}

