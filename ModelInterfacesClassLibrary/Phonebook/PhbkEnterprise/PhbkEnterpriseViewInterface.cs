using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise {
    public interface IPhbkEnterpriseView
    {
        [JsonProperty(PropertyName = "entrprsId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        System.Int32  EntrprsId { get; set; }

        [JsonProperty(PropertyName = "entrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        System.String  EntrprsName { get; set; }

        [JsonProperty(PropertyName = "entrprsDesc")]
        [Display(Description="Description of the Enterprise",Name="Description of the Enterprise",Prompt="Description Enterprise Name",ShortName="Enterprise Description")]
        [StringLength(250,ErrorMessage="Invalid")]
        System.String  EntrprsDesc { get; set; }

    }
}

