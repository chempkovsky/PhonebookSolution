using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserpermsView;

namespace ModelServicesPrismModule.asp.aspnetuserpermsView {
    public class AspnetuserpermsView: IAspnetuserpermsView
    {
        [JsonProperty(PropertyName = "modelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  ModelName { get; set; }

        [JsonProperty(PropertyName = "userPerms")]
        [Required]
        [Display(Description="User Perms",Name="User Perms",Prompt="Enter User Perms",ShortName="User Perms")]
        public System.Int32  UserPerms { get; set; }

    }
}

