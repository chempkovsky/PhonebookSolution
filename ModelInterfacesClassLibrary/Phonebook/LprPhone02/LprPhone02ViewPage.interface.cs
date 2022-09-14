using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone02;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone02 {
    public interface ILprPhone02ViewPage
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
        IList<ILprPhone02View> items { get; set; }
    }
}

