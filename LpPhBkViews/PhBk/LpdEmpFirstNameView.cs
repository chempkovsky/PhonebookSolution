using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace LpPhBkViews.PhBk {
    public class LpdEmpFirstNameView {
        // [JsonProperty(PropertyName = "empFirstNameId")]
        [JsonPropertyName("empFirstNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpFirstNameId { get; set; }

        // [JsonProperty(PropertyName = "empFirstName")]
        [JsonPropertyName("empFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpFirstName { get; set; } = null!;

    }
}

