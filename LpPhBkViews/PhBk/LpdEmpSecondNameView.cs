using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace LpPhBkViews.PhBk {
    public class LpdEmpSecondNameView {
        // [JsonProperty(PropertyName = "empSecondNameId")]
        [JsonPropertyName("empSecondNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpSecondNameId { get; set; }

        // [JsonProperty(PropertyName = "empSecondName")]
        [JsonPropertyName("empSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        public System.String ?  EmpSecondName { get; set; } = null!;

    }
}

