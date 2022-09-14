using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IRegisterModel
    {
        [JsonProperty(PropertyName = "Email")]
        string  Email { get; set; }

        [JsonProperty(PropertyName = "Password")]
        string  Password { get; set; }

        [JsonProperty(PropertyName = "ConfirmPassword")]
        string  ConfirmPassword { get; set; }
    }
}

