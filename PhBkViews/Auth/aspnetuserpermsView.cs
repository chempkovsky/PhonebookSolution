using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace PhBkViews.Auth {
    public class aspnetuserpermsView {
        // [JsonProperty(PropertyName = "modelName")]
        [JsonPropertyName("modelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  ModelName { get; set; } = null!;

        // [JsonProperty(PropertyName = "userPerms")]
        [JsonPropertyName("userPerms")]
        [Required]
        [Display(Description="User Perms",Name="User Perms",Prompt="Enter User Perms",ShortName="User Perms")]
        public System.Int32  UserPerms { get; set; }

    }
}

