using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.LprDivision01 {
    public interface ILprDivision01View
    {
        [JsonProperty(PropertyName = "divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        System.Int32  DivisionId { get; set; }

        [JsonProperty(PropertyName = "divisionNameIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        System.Int32  DivisionNameIdRef { get; set; }

    }
}

