using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.LpdPhone {
    public interface ILpdPhoneView
    {
        [JsonProperty(PropertyName = "lpdPhoneId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        System.Int32  LpdPhoneId { get; set; }

        [JsonProperty(PropertyName = "phone")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone",Prompt="Enter Phone",ShortName="Phone")]
        System.String  Phone { get; set; }

    }
}

