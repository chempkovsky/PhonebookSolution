using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType {
    public interface IPhbkPhoneTypeView
    {
        [JsonProperty(PropertyName = "phoneTypeId")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        System.Int32  PhoneTypeId { get; set; }

        [JsonProperty(PropertyName = "phoneTypeName")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone Type Name",Prompt="Enter Phone Type Name",ShortName="Phone Type Name")]
        System.String  PhoneTypeName { get; set; }

        [JsonProperty(PropertyName = "phoneTypeDesc")]
        [Display(Description="Description of the Phone Type",Name="Phone Type Description",Prompt="Enter Phone Type Description",ShortName="Phone Type Description")]
        [StringLength(250,ErrorMessage="Invalid")]
        System.String  PhoneTypeDesc { get; set; }

    }
}

