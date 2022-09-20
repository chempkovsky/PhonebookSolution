using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IChangePasswordModel
    {
        [JsonProperty(PropertyName = "oldpassword")]
        string  OldPassword { get; set; }

        [JsonProperty(PropertyName = "newPassword")]
        string  NewPassword { get; set; }

        [JsonProperty(PropertyName = "confirmPassword")]
        string  ConfirmPassword { get; set; }
    }
}

