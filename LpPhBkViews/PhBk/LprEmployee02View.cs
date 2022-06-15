using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace LpPhBkViews.PhBk {
    public class LprEmployee02View {
        // [JsonProperty(PropertyName = "employeeId")]
        [JsonPropertyName("employeeId")]
        [Required]
        [Display(Description="Emp Row id",Name="Id of the Employee",Prompt="Enter Employee Id",ShortName="Employee Id")]
        public System.Int32  EmployeeId { get; set; }

        // [JsonProperty(PropertyName = "empLastNameIdRef")]
        [JsonPropertyName("empLastNameIdRef")]
        [Required]
        [Display(Description="Lst name ref id",Name="Lst name  ref Id",Prompt="Enter Lst name ref Id",ShortName="Lst name ref Id")]
        public System.Int32  EmpLastNameIdRef { get; set; }

        // [JsonProperty(PropertyName = "empFirstNameIdRef")]
        [JsonPropertyName("empFirstNameIdRef")]
        [Required]
        [Display(Description="Frst name ref id",Name="Frst name  ref Id",Prompt="Enter Frst name ref Id",ShortName="Frst name ref Id")]
        public System.Int32  EmpFirstNameIdRef { get; set; }

        // [JsonProperty(PropertyName = "empSecondNameIdRef")]
        [JsonPropertyName("empSecondNameIdRef")]
        [Required]
        [Display(Description="Sec name ref id",Name="Sec name  ref Id",Prompt="Enter Sec name ref Id",ShortName="Sec name ref Id")]
        public System.Int32  EmpSecondNameIdRef { get; set; }

        // [JsonProperty(PropertyName = "divisionIdRef")]
        [JsonPropertyName("divisionIdRef")]
        [Required]
        [Display(Description="Division Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionIdRef { get; set; }

    }
}

