using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface ILoginModel
    {
        [JsonProperty(PropertyName = "username")]
        string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        string Password { get; set; }

        [JsonProperty(PropertyName = "grant_type")]
        string GrantType { get; set; }
    }
}

