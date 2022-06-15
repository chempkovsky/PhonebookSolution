using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace LpPhBkViews.PhBk {
    public class LprDivision02View {
        // [JsonProperty(PropertyName = "divisionId")]
        [JsonPropertyName("divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionId { get; set; }

        // [JsonProperty(PropertyName = "entrprsIdRef")]
        [JsonPropertyName("entrprsIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        public System.Int32  EntrprsIdRef { get; set; }

        // [JsonProperty(PropertyName = "divisionNameIdRef")]
        [JsonPropertyName("divisionNameIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the DivisionName Row",Prompt="Enter DivisionName Row Id",ShortName="DivisionName Row Id")]
        public System.Int32  DivisionNameIdRef { get; set; }

    }
}

