using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;

namespace ModelServicesPrismModule.asp.aspnetmodelView {
    public class AspnetmodelView: IAspnetmodelView
    {
        [JsonProperty(PropertyName = "modelPk")]
        [Required]
        [Display(Description="Model Id",Name="Model Id",Prompt="Enter Model Id",ShortName="Id")]
        public System.Int32  ModelPk { get; set; }

        [JsonProperty(PropertyName = "modelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  ModelName { get; set; }

        [JsonProperty(PropertyName = "modelDescription")]
        [Display(Description="Model Description",Name="Model Description",Prompt="Enter ModelDescription",ShortName="Description")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  ModelDescription { get; set; }

    }
}

