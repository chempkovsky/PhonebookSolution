using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone03;

namespace ModelServicesPrismModule.Phonebook.LprPhone03 {
    public class LprPhone03View: ILprPhone03View
    {
        [JsonProperty(PropertyName = "phoneId")]
        [Required]
        [Display(Description="Row id",Name="Phone Id",Prompt="Enter Phone Id",ShortName="Phone Id")]
        public System.Int32  PhoneId { get; set; }

        [JsonProperty(PropertyName = "lpdPhoneIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  LpdPhoneIdRef { get; set; }

        [JsonProperty(PropertyName = "phoneTypeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        public System.Int32  PhoneTypeIdRef { get; set; }

    }
}

