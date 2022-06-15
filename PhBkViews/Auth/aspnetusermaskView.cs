using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace PhBkViews.Auth {
    public class aspnetusermaskView {
        // [JsonProperty(PropertyName = "userId")]
        [JsonPropertyName("userId")]
        [Required]
        [Display(Description="User Id",Name="User Id",Prompt="Enter Id",ShortName="User Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  UserId { get; set; } = null!;

        // [JsonProperty(PropertyName = "mask1")]
        [JsonPropertyName("mask1")]
        [Required]
        [Display(Description="Permission to Sel",Name="Permission to Sel",Prompt="Enter permission to Sel",ShortName="Sel")]
        public System.Boolean  Mask1 { get; set; }

        // [JsonProperty(PropertyName = "mask2")]
        [JsonPropertyName("mask2")]
        [Required]
        [Display(Description="Permission to Del",Name="Permission to Del",Prompt="Enter permission to Del",ShortName="Del")]
        public System.Boolean  Mask2 { get; set; }

        // [JsonProperty(PropertyName = "mask3")]
        [JsonPropertyName("mask3")]
        [Required]
        [Display(Description="Permission to Upd",Name="Permission to Upd",Prompt="Enter permission to Upd",ShortName="Upd")]
        public System.Boolean  Mask3 { get; set; }

        // [JsonProperty(PropertyName = "mask4")]
        [JsonPropertyName("mask4")]
        [Required]
        [Display(Description="Permission to Add",Name="Permission to Add",Prompt="Enter permission to Add",ShortName="Add")]
        public System.Boolean  Mask4 { get; set; }

        // [JsonProperty(PropertyName = "mask5")]
        [JsonPropertyName("mask5")]
        [Required]
        [Display(Description="Full scan permission",Name="Full scan permission",Prompt="Enter Full scan permission",ShortName="FullScan")]
        public System.Boolean  Mask5 { get; set; }

        // [JsonProperty(PropertyName = "modelPkRef")]
        [JsonPropertyName("modelPkRef")]
        [Required]
        [Display(Description="Model Id",Name="Model Id",Prompt="Enter Model Id",ShortName="Id")]
        public System.Int32  ModelPkRef { get; set; }

        // [JsonProperty(PropertyName = "uEmail")]
        [JsonPropertyName("uEmail")]
        [Display(Description="User Email",Name="User Email",Prompt="Enter Email",ShortName="User Email")]
        [StringLength(256,MinimumLength=0,ErrorMessage="Invalid")]
        public System.String ?  UEmail { get; set; } = null!;

        // [JsonProperty(PropertyName = "uUserName")]
        [JsonPropertyName("uUserName")]
        [Display(Description="User Name",Name="User Name",Prompt="Enter User Name",ShortName="User Name")]
        [StringLength(256,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String ?  UUserName { get; set; } = null!;

        // [JsonProperty(PropertyName = "mModelName")]
        [JsonPropertyName("mModelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  MModelName { get; set; } = null!;

    }
}

