using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace LpPhBkViews.PhBk {
    public class LpdEmpLastNameView {
        // [JsonProperty(PropertyName = "empLastNameId")]
        [JsonPropertyName("empLastNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpLastNameId { get; set; }

        // [JsonProperty(PropertyName = "empLastName")]
        [JsonPropertyName("empLastName")]
        [Required]
        [Display(Description="Last Name of the Employee",Name="Employee Last Name",Prompt="Enter Employee Last Name",ShortName="Last Name")]
        [StringLength(40,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpLastName { get; set; } = null!;

    }
}

