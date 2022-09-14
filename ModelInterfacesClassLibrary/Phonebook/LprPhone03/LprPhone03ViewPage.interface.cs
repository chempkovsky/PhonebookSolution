using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone03;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone03 {
    public interface ILprPhone03ViewPage
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
        IList<ILprPhone03View> items { get; set; }
    }
}

