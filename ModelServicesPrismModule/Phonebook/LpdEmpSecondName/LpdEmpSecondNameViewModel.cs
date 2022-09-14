using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpSecondName {
    public class LpdEmpSecondNameView: ILpdEmpSecondNameView
    {
        [JsonProperty(PropertyName = "empSecondNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpSecondNameId { get; set; }

        [JsonProperty(PropertyName = "empSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        public System.String  EmpSecondName { get; set; }

    }
}

