using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonServicesPrismModule.Models {
    public class BearerTokenModel: IBearerTokenModel
    {
        [JsonProperty(PropertyName = "token_type")]
        public string  token_type { get; set; }

        [JsonProperty(PropertyName = "user_name")]
        public string  userName { get; set; }

        [JsonProperty(PropertyName = "access_token")]
        public string  access_token { get; set; }

        [JsonProperty(PropertyName = "expiration")]
        public DateTime  expiration { get; set; }
    }
}

