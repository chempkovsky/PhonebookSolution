using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;


namespace PhBkViews.PhBk {
    public class PhbkPhoneTypeView {
        // [JsonProperty(PropertyName = "phoneTypeId")]
        [JsonPropertyName("phoneTypeId")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        public System.Int32  PhoneTypeId { get; set; }

        // [JsonProperty(PropertyName = "phoneTypeName")]
        [JsonPropertyName("phoneTypeName")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone Type Name",Prompt="Enter Phone Type Name",ShortName="Phone Type Name")]
        public System.String  PhoneTypeName { get; set; } = null!;

        // [JsonProperty(PropertyName = "phoneTypeDesc")]
        [JsonPropertyName("phoneTypeDesc")]
        [Display(Description="Description of the Phone Type",Name="Phone Type Description",Prompt="Enter Phone Type Description",ShortName="Phone Type Description")]
        [StringLength(250,ErrorMessage="Invalid")]
        public System.String ?  PhoneTypeDesc { get; set; }

    }
}

