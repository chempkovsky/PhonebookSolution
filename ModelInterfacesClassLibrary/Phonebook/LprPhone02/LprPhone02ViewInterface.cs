using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.LprPhone02 {
    public interface ILprPhone02View
    {
        [JsonProperty(PropertyName = "phoneId")]
        [Required]
        [Display(Description="Row id",Name="Phone Id",Prompt="Enter Phone Id",ShortName="Phone Id")]
        System.Int32  PhoneId { get; set; }

        [JsonProperty(PropertyName = "lpdPhoneIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        System.Int32  LpdPhoneIdRef { get; set; }

        [JsonProperty(PropertyName = "employeeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        System.Int32  EmployeeIdRef { get; set; }

    }
}

