using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IBearerTokenModel
    {
        [JsonProperty(PropertyName = "access_token")]
        string  access_token { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        string  token_type { get; set; }

        [JsonProperty(PropertyName = "userName")]
        string  userName { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        string  expires_in { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        DateTime  issued { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        DateTime  expires { get; set; }
    }
}

