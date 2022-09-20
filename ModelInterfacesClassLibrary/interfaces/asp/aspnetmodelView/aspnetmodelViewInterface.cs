using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView {
    public interface IAspnetmodelView
    {
        [JsonProperty(PropertyName = "modelPk")]
        [Required]
        [Display(Description="Model Id",Name="Model Id",Prompt="Enter Model Id",ShortName="Id")]
        System.Int32  ModelPk { get; set; }

        [JsonProperty(PropertyName = "modelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  ModelName { get; set; }

        [JsonProperty(PropertyName = "modelDescription")]
        [Display(Description="Model Description",Name="Model Description",Prompt="Enter ModelDescription",ShortName="Description")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  ModelDescription { get; set; }

    }
}

