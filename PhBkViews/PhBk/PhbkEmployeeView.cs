using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace PhBkViews.PhBk {
    public class PhbkEmployeeView {
        // [JsonProperty(PropertyName = "employeeId")]
        [JsonPropertyName("employeeId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeId { get; set; }

        // [JsonProperty(PropertyName = "empFirstName")]
        [JsonPropertyName("empFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpFirstName { get; set; } = null!;

        // [JsonProperty(PropertyName = "empLastName")]
        [JsonPropertyName("empLastName")]
        [Required]
        [Display(Description="Last Name of the Employee",Name="Employee Last Name",Prompt="Enter Employee Last Name",ShortName="Last Name")]
        [StringLength(40,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpLastName { get; set; } = null!;

        // [JsonProperty(PropertyName = "empSecondName")]
        [JsonPropertyName("empSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        public System.String ?  EmpSecondName { get; set; }

        // [JsonProperty(PropertyName = "divisionIdRef")]
        [JsonPropertyName("divisionIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionIdRef { get; set; }

        // [JsonProperty(PropertyName = "dDivisionName")]
        [JsonPropertyName("dDivisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DDivisionName { get; set; } = null!;

        // [JsonProperty(PropertyName = "dEEntrprsName")]
        [JsonPropertyName("dEEntrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DEEntrprsName { get; set; } = null!;

    }
}

