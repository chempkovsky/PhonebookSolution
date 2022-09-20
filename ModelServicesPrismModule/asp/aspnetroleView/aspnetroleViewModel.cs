using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;

namespace ModelServicesPrismModule.asp.aspnetroleView {
    public class AspnetroleView: IAspnetroleView
    {
        [JsonProperty(PropertyName = "id")]
        [Required]
        [Display(Description="Role Id",Name="Role Id",Prompt="Enter Id",ShortName="Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [Required]
        [Display(Description="Role Name",Name="Role Name",Prompt="Enter RoleName",ShortName="Role Name")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  Name { get; set; }

    }
}

