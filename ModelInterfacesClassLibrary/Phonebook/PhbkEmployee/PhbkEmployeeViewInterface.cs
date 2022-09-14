using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkEmployee {
    public interface IPhbkEmployeeView
    {
        [JsonProperty(PropertyName = "employeeId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        System.Int32  EmployeeId { get; set; }

        [JsonProperty(PropertyName = "empFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        System.String  EmpFirstName { get; set; }

        [JsonProperty(PropertyName = "empLastName")]
        [Required]
        [Display(Description="Last Name of the Employee",Name="Employee Last Name",Prompt="Enter Employee Last Name",ShortName="Last Name")]
        [StringLength(40,MinimumLength=3,ErrorMessage="Invalid")]
        System.String  EmpLastName { get; set; }

        [JsonProperty(PropertyName = "empSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        System.String  EmpSecondName { get; set; }

        [JsonProperty(PropertyName = "divisionIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        System.Int32  DivisionIdRef { get; set; }

        [JsonProperty(PropertyName = "dDivisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        System.String  DDivisionName { get; set; }

        [JsonProperty(PropertyName = "dEEntrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        System.String  DEEntrprsName { get; set; }

    }
}

