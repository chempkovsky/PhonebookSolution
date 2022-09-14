using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;

namespace ModelServicesPrismModule.Phonebook.PhbkDivision {
    public class PhbkDivisionView: IPhbkDivisionView
    {
        [JsonProperty(PropertyName = "divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionId { get; set; }

        [JsonProperty(PropertyName = "divisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DivisionName { get; set; }

        [JsonProperty(PropertyName = "divisionDesc")]
        [Display(Description="Description of the Enterprise Division",Name="Description of the Division",Prompt="Enter Enterprise Division Description",ShortName="Division Description")]
        [StringLength(250,ErrorMessage="Invalid")]
        public System.String  DivisionDesc { get; set; }

        [JsonProperty(PropertyName = "entrprsIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        public System.Int32  EntrprsIdRef { get; set; }

        [JsonProperty(PropertyName = "eEntrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EEntrprsName { get; set; }

    }
}

