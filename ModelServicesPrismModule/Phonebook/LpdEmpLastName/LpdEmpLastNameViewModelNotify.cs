using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpLastName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpLastName {
    public class LpdEmpLastNameViewNotify: ILpdEmpLastNameViewNotify
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        public override string ToString()
        {
            return "" 
            + _EmpLastNameId
            + _EmpLastName
            ;
        }

        protected System.Int32  _EmpLastNameId;
        [JsonProperty(PropertyName = "empLastNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpLastNameId { 
            get { return _EmpLastNameId; }
            set { if(_EmpLastNameId != value) { _EmpLastNameId = value; OnPropertyChanged(); } }
        }
        protected System.String  _EmpLastName;
        [JsonProperty(PropertyName = "empLastName")]
        [Required]
        [Display(Description="Last Name of the Employee",Name="Employee Last Name",Prompt="Enter Employee Last Name",ShortName="Last Name")]
        [StringLength(40,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpLastName { 
            get { return _EmpLastName; }
            set { if(_EmpLastName != value) { _EmpLastName = value; OnPropertyChanged(); } }
        }
    }
}

