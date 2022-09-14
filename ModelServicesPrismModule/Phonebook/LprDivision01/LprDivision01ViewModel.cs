using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprDivision01;

namespace ModelServicesPrismModule.Phonebook.LprDivision01 {
    public class LprDivision01View: ILprDivision01View
    {
        [JsonProperty(PropertyName = "divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionId { get; set; }

        [JsonProperty(PropertyName = "divisionNameIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionNameIdRef { get; set; }

    }
}

