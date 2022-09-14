using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IChangePasswordModel
    {
        [JsonProperty(PropertyName = "OldPassword")]
        string  OldPassword { get; set; }

        [JsonProperty(PropertyName = "NewPassword")]
        string  NewPassword { get; set; }

        [JsonProperty(PropertyName = "ConfirmPassword")]
        string  ConfirmPassword { get; set; }
    }
}

