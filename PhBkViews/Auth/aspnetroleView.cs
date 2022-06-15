using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace PhBkViews.Auth {
    public class aspnetroleView {
        // [JsonProperty(PropertyName = "id")]
        [JsonPropertyName("id")]
        [Required]
        [Display(Description="Role Id",Name="Role Id",Prompt="Enter Id",ShortName="Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  Id { get; set; } = null!;

        // [JsonProperty(PropertyName = "name")]
        [JsonPropertyName("name")]
        [Required]
        [Display(Description="Role Name",Name="Role Name",Prompt="Enter RoleName",ShortName="Role Name")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  Name { get; set; } = null!;

    }
}

