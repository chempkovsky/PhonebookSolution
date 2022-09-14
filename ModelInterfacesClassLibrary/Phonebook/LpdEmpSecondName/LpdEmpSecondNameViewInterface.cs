using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName {
    public interface ILpdEmpSecondNameView
    {
        [JsonProperty(PropertyName = "empSecondNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        System.Int32  EmpSecondNameId { get; set; }

        [JsonProperty(PropertyName = "empSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        System.String  EmpSecondName { get; set; }

    }
}

