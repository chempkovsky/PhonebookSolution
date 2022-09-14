using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdDivision;

namespace ModelServicesPrismModule.Phonebook.LpdDivision {
    public class LpdDivisionView: ILpdDivisionView
    {
        [JsonProperty(PropertyName = "divisionNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  DivisionNameId { get; set; }

        [JsonProperty(PropertyName = "divisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DivisionName { get; set; }

    }
}

