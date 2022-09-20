using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IBearerTokenModel
    {
        [JsonProperty(PropertyName = "token_type")]
        string  token_type { get; set; }

        [JsonProperty(PropertyName = "user_name")]
        string  userName { get; set; }

        [JsonProperty(PropertyName = "access_token")]
        string  access_token { get; set; }

        [JsonProperty(PropertyName = "expiration")]
        DateTime  expiration { get; set; }
    }
}

