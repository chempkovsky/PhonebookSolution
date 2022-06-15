using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace PhBkViews.PhBk {
    public class PhbkEnterpriseView {
        // [JsonProperty(PropertyName = "entrprsId")]
        [JsonPropertyName("entrprsId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        public System.Int32  EntrprsId { get; set; }

        // [JsonProperty(PropertyName = "entrprsName")]
        [JsonPropertyName("entrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EntrprsName { get; set; } = null!;

        // [JsonProperty(PropertyName = "entrprsDesc")]
        [JsonPropertyName("entrprsDesc")]
        [Display(Description="Description of the Enterprise",Name="Description of the Enterprise",Prompt="Description Enterprise Name",ShortName="Enterprise Description")]
        [StringLength(250,ErrorMessage="Invalid")]
        public System.String ?  EntrprsDesc { get; set; }

    }
}

