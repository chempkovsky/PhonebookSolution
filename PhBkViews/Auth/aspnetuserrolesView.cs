using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace PhBkViews.Auth {
    public class aspnetuserrolesView {
        // [JsonProperty(PropertyName = "userId")]
        [JsonPropertyName("userId")]
        [Required]
        [Display(Description="User Id",Name="User Id",Prompt="Enter Id",ShortName="User Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  UserId { get; set; } = null!;

        // [JsonProperty(PropertyName = "roleId")]
        [JsonPropertyName("roleId")]
        [Required]
        [Display(Description="Role Id",Name="Role Id",Prompt="Enter Id",ShortName="Role Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  RoleId { get; set; } = null!;

        // [JsonProperty(PropertyName = "uLockoutEnd")]
        [JsonPropertyName("uLockoutEnd")]
        [Display(Description="Lockout End",Name="Lockout End",Prompt="Enter Lockout",ShortName="Lockout End")]
        public System.DateTimeOffset ?  ULockoutEnd { get; set; }

        // [JsonProperty(PropertyName = "uUserName")]
        [JsonPropertyName("uUserName")]
        [Display(Description="User Name",Name="User Name",Prompt="Enter User Name",ShortName="User Name")]
        [StringLength(256,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String ?  UUserName { get; set; } = null!;

        // [JsonProperty(PropertyName = "rName")]
        [JsonPropertyName("rName")]
        [Required]
        [Display(Description="Role Name",Name="Role Name",Prompt="Enter RoleName",ShortName="Role Name")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  RName { get; set; } = null!;

    }
}

