using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonServicesPrismModule.Models {
    public class RegisterModel: IRegisterModel
    {
        [JsonProperty(PropertyName = "Email")]
        public string  Email { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string  Password { get; set; }

        [JsonProperty(PropertyName = "ConfirmPassword")]
        public string  ConfirmPassword { get; set; }
    }
}

