using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName {
    public interface ILpdEmpFirstNameView
    {
        [JsonProperty(PropertyName = "empFirstNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        System.Int32  EmpFirstNameId { get; set; }

        [JsonProperty(PropertyName = "empFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        System.String  EmpFirstName { get; set; }

    }
}

