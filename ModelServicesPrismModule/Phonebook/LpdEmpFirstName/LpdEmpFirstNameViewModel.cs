using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpFirstName {
    public class LpdEmpFirstNameView: ILpdEmpFirstNameView
    {
        [JsonProperty(PropertyName = "empFirstNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpFirstNameId { get; set; }

        [JsonProperty(PropertyName = "empFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpFirstName { get; set; }

    }
}

