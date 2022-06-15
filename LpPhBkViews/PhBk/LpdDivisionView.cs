using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace LpPhBkViews.PhBk {
    public class LpdDivisionView {
        // [JsonProperty(PropertyName = "divisionNameId")]
        [JsonPropertyName("divisionNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  DivisionNameId { get; set; }

        // [JsonProperty(PropertyName = "divisionName")]
        [JsonPropertyName("divisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DivisionName { get; set; } = null!;

    }
}

