using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView {
    public interface IAspnetrolemaskView
    {
        [JsonProperty(PropertyName = "roleDescription")]
        [Display(Description="Role Description",Name="Role Description",Prompt="Enter Role Description",ShortName="Description")]
        [StringLength(70,MinimumLength=0,ErrorMessage="Invalid")]
        System.String  RoleDescription { get; set; }

        [JsonProperty(PropertyName = "mask1")]
        [Required]
        [Display(Description="Permission to Sel",Name="Permission to Sel",Prompt="Enter permission to Sel",ShortName="Sel")]
        System.Boolean  Mask1 { get; set; }

        [JsonProperty(PropertyName = "mask2")]
        [Required]
        [Display(Description="Permission to Del",Name="Permission to Del",Prompt="Enter permission to Del",ShortName="Del")]
        System.Boolean  Mask2 { get; set; }

        [JsonProperty(PropertyName = "mask3")]
        [Required]
        [Display(Description="Permission to Upd",Name="Permission to Upd",Prompt="Enter permission to Upd",ShortName="Upd")]
        System.Boolean  Mask3 { get; set; }

        [JsonProperty(PropertyName = "mask4")]
        [Required]
        [Display(Description="Permission to Add",Name="Permission to Add",Prompt="Enter permission to Add",ShortName="Add")]
        System.Boolean  Mask4 { get; set; }

        [JsonProperty(PropertyName = "mask5")]
        [Required]
        [Display(Description="Full scan permission",Name="Full scan permission",Prompt="Enter Full scan permission",ShortName="FullScan")]
        System.Boolean  Mask5 { get; set; }

        [JsonProperty(PropertyName = "modelPkRef")]
        [Required]
        [Display(Description="Model Id",Name="Model Id",Prompt="Enter Model Id",ShortName="Id")]
        System.Int32  ModelPkRef { get; set; }

        [JsonProperty(PropertyName = "mModelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  MModelName { get; set; }

        [JsonProperty(PropertyName = "rName")]
        [Required]
        [Display(Description="Role Name",Name="Role Name",Prompt="Enter RoleName",ShortName="Role Name")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  RName { get; set; }

    }
}

