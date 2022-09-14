using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprDivision02;

namespace ModelServicesPrismModule.Phonebook.LprDivision02 {
    public class LprDivision02View: ILprDivision02View
    {
        [JsonProperty(PropertyName = "divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionId { get; set; }

        [JsonProperty(PropertyName = "entrprsIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        public System.Int32  EntrprsIdRef { get; set; }

        [JsonProperty(PropertyName = "divisionNameIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the DivisionName Row",Prompt="Enter DivisionName Row Id",ShortName="DivisionName Row Id")]
        public System.Int32  DivisionNameIdRef { get; set; }

    }
}

