using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace LpPhBkViews.PhBk {
    public class LprEmployee01View {
        // [JsonProperty(PropertyName = "employeeId")]
        [JsonPropertyName("employeeId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeId { get; set; }

        // [JsonProperty(PropertyName = "empLastNameIdRef")]
        [JsonPropertyName("empLastNameIdRef")]
        [Required]
        [Display(Description="Row ref id",Name="ref Id of the Row",Prompt="Enter Row ref Id",ShortName="Row ref Id")]
        public System.Int32  EmpLastNameIdRef { get; set; }

        // [JsonProperty(PropertyName = "empFirstNameIdRef")]
        [JsonPropertyName("empFirstNameIdRef")]
        [Required]
        [Display(Description="Row ref id",Name="ref Id of the Row",Prompt="Enter Row ref Id",ShortName="Row ref Id")]
        public System.Int32  EmpFirstNameIdRef { get; set; }

        // [JsonProperty(PropertyName = "empSecondNameIdRef")]
        [JsonPropertyName("empSecondNameIdRef")]
        [Required]
        [Display(Description="S name ref id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpSecondNameIdRef { get; set; }

    }
}

