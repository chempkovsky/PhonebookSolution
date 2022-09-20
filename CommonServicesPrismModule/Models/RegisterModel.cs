using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonServicesPrismModule.Models {
    public class RegisterModel: IRegisterModel
    {
        [JsonProperty(PropertyName = "email")]
        public string  Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string  Password { get; set; }

        [JsonProperty(PropertyName = "confirmPassword")]
        public string  ConfirmPassword { get; set; }
    }
}

