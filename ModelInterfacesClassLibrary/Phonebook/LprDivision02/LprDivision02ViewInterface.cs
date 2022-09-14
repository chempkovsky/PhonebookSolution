using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.LprDivision02 {
    public interface ILprDivision02View
    {
        [JsonProperty(PropertyName = "divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        System.Int32  DivisionId { get; set; }

        [JsonProperty(PropertyName = "entrprsIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        System.Int32  EntrprsIdRef { get; set; }

        [JsonProperty(PropertyName = "divisionNameIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the DivisionName Row",Prompt="Enter DivisionName Row Id",ShortName="DivisionName Row Id")]
        System.Int32  DivisionNameIdRef { get; set; }

    }
}

