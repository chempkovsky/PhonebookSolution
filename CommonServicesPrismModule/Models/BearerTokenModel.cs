using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonServicesPrismModule.Models {
    public class BearerTokenModel: IBearerTokenModel
    {
        [JsonProperty(PropertyName = "access_token")]
        public string  access_token { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string  token_type { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string  userName { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public string  expires_in { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        public DateTime  issued { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime  expires { get; set; }
    }
}

