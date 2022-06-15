using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace LpPhBkViews.PhBk {
    public class LprDivision01View {
        // [JsonProperty(PropertyName = "divisionId")]
        [JsonPropertyName("divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionId { get; set; }

        // [JsonProperty(PropertyName = "divisionNameIdRef")]
        [JsonPropertyName("divisionNameIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionNameIdRef { get; set; }

        // [JsonProperty(PropertyName = "nDDivisionNameId")]
        [JsonPropertyName("nDDivisionNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  NDDivisionNameId { get; set; }

        // [JsonProperty(PropertyName = "nDDivisionName")]
        [JsonPropertyName("nDDivisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  NDDivisionName { get; set; } = null!;

    }
}

