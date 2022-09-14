using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprDivision02;

namespace ModelInterfacesClassLibrary.Phonebook.LprDivision02 {
    public interface ILprDivision02ViewPage
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
        IList<ILprDivision02View> items { get; set; }
    }
}

