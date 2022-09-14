using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee01;

namespace ModelServicesPrismModule.Phonebook.LprEmployee01 {
    public class LprEmployee01View: ILprEmployee01View
    {
        [JsonProperty(PropertyName = "employeeId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeId { get; set; }

        [JsonProperty(PropertyName = "empLastNameIdRef")]
        [Required]
        [Display(Description="Row ref id",Name="ref Id of the Row",Prompt="Enter Row ref Id",ShortName="Row ref Id")]
        public System.Int32  EmpLastNameIdRef { get; set; }

        [JsonProperty(PropertyName = "empFirstNameIdRef")]
        [Required]
        [Display(Description="Row ref id",Name="ref Id of the Row",Prompt="Enter Row ref Id",ShortName="Row ref Id")]
        public System.Int32  EmpFirstNameIdRef { get; set; }

        [JsonProperty(PropertyName = "empSecondNameIdRef")]
        [Required]
        [Display(Description="S name ref id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpSecondNameIdRef { get; set; }

    }
}

