using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView {
    public interface IaspnetrolemaskViewPage
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
        IList<IAspnetrolemaskView> items { get; set; }
    }
}

