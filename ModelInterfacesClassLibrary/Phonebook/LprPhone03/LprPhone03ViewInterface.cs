using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone03 {
    public interface ILprPhone03View
    {
        [JsonProperty(PropertyName = "phoneId")]
        [Required]
        [Display(Description="Row id",Name="Phone Id",Prompt="Enter Phone Id",ShortName="Phone Id")]
        System.Int32  PhoneId { get; set; }

        [JsonProperty(PropertyName = "lpdPhoneIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        System.Int32  LpdPhoneIdRef { get; set; }

        [JsonProperty(PropertyName = "phoneTypeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        System.Int32  PhoneTypeIdRef { get; set; }

    }
}

