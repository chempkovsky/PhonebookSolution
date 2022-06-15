using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace PhBkViews.PhBk {
    public class PhbkPhoneView {
        // [JsonProperty(PropertyName = "phoneId")]
        [JsonPropertyName("phoneId")]
        [Required]
        [Display(Description="Row id",Name="Phone Id",Prompt="Enter Phone Id",ShortName="Phone Id")]
        public System.Int32  PhoneId { get; set; }

        // [JsonProperty(PropertyName = "phone")]
        [JsonPropertyName("phone")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone",Prompt="Enter Phone",ShortName="Phone")]
        public System.String  Phone { get; set; } = null!;

        // [JsonProperty(PropertyName = "phoneTypeIdRef")]
        [JsonPropertyName("phoneTypeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        public System.Int32  PhoneTypeIdRef { get; set; }

        // [JsonProperty(PropertyName = "employeeIdRef")]
        [JsonPropertyName("employeeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeIdRef { get; set; }

        // [JsonProperty(PropertyName = "pPhoneTypeName")]
        [JsonPropertyName("pPhoneTypeName")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone Type Name",Prompt="Enter Phone Type Name",ShortName="Phone Type Name")]
        public System.String  PPhoneTypeName { get; set; } = null!;

        // [JsonProperty(PropertyName = "eEmpFirstName")]
        [JsonPropertyName("eEmpFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EEmpFirstName { get; set; } = null!;

        // [JsonProperty(PropertyName = "eEmpLastName")]
        [JsonPropertyName("eEmpLastName")]
        [Required]
        [Display(Description="Last Name of the Employee",Name="Employee Last Name",Prompt="Enter Employee Last Name",ShortName="Last Name")]
        [StringLength(40,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EEmpLastName { get; set; } = null!;

        // [JsonProperty(PropertyName = "eEmpSecondName")]
        [JsonPropertyName("eEmpSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        public System.String ?  EEmpSecondName { get; set; }

        // [JsonProperty(PropertyName = "eDDivisionName")]
        [JsonPropertyName("eDDivisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EDDivisionName { get; set; } = null!;

        // [JsonProperty(PropertyName = "eDEEntrprsName")]
        [JsonPropertyName("eDEEntrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EDEEntrprsName { get; set; } = null!;

    }
}

