using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IRegisterModel
    {
        [JsonProperty(PropertyName ="email")]
        string  Email { get; set; }

        [JsonProperty(PropertyName ="password")]
        string  Password { get; set; }

        [JsonProperty(PropertyName ="confirmPassword")]
        string  ConfirmPassword { get; set; }
    }
}

