using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpLastName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpLastName {
    public class LpdEmpLastNameView: ILpdEmpLastNameView
    {
        [JsonProperty(PropertyName = "empLastNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpLastNameId { get; set; }

        [JsonProperty(PropertyName = "empLastName")]
        [Required]
        [Display(Description="Last Name of the Employee",Name="Employee Last Name",Prompt="Enter Employee Last Name",ShortName="Last Name")]
        [StringLength(40,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpLastName { get; set; }

    }
}

