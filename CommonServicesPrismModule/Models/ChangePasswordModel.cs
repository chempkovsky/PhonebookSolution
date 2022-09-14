using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonServicesPrismModule.Models {
    public class ChangePasswordModel: IChangePasswordModel
    {
        [JsonProperty(PropertyName = "OldPassword")]
        public string  OldPassword { get; set; }

        [JsonProperty(PropertyName = "NewPassword")]
        public string  NewPassword { get; set; }

        [JsonProperty(PropertyName = "ConfirmPassword")]
        public string  ConfirmPassword { get; set; }
    }
}

