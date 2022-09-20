using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonServicesPrismModule.Models {
    public class ChangePasswordModel: IChangePasswordModel
    {
        [JsonProperty(PropertyName = "oldpassword")]
        public string  OldPassword { get; set; }

        [JsonProperty(PropertyName = "newPassword")]
        public string  NewPassword { get; set; }

        [JsonProperty(PropertyName = "confirmPassword")]
        public string  ConfirmPassword { get; set; }
    }
}

