using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView {
    public interface IAspnetuserrolesView
    {
        [JsonProperty(PropertyName = "userId")]
        [Required]
        [Display(Description="User Id",Name="User Id",Prompt="Enter Id",ShortName="User Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  UserId { get; set; }

        [JsonProperty(PropertyName = "roleId")]
        [Required]
        [Display(Description="Role Id",Name="Role Id",Prompt="Enter Id",ShortName="Role Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  RoleId { get; set; }

        [JsonProperty(PropertyName = "uLockoutEnd")]
        [Display(Description="Lockout End",Name="Lockout End",Prompt="Enter Lockout",ShortName="Lockout End")]
        System.DateTimeOffset ?  ULockoutEnd { get; set; }

        [JsonProperty(PropertyName = "uUserName")]
        [Display(Description="User Name",Name="User Name",Prompt="Enter User Name",ShortName="User Name")]
        [StringLength(256,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  UUserName { get; set; }

        [JsonProperty(PropertyName = "rName")]
        [Required]
        [Display(Description="Role Name",Name="Role Name",Prompt="Enter RoleName",ShortName="Role Name")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  RName { get; set; }

    }
}

