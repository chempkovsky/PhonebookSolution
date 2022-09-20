using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserpermsView {
    public interface IAspnetuserpermsView
    {
        [JsonProperty(PropertyName = "modelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  ModelName { get; set; }

        [JsonProperty(PropertyName = "userPerms")]
        [Required]
        [Display(Description="User Perms",Name="User Perms",Prompt="Enter User Perms",ShortName="User Perms")]
        System.Int32  UserPerms { get; set; }

    }
}

