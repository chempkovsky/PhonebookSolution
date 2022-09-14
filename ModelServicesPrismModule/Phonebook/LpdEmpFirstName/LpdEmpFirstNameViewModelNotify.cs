using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpFirstName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpFirstName {
    public class LpdEmpFirstNameViewNotify: ILpdEmpFirstNameViewNotify
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
            + _EmpFirstNameId
            + _EmpFirstName
            ;
        }

        protected System.Int32  _EmpFirstNameId;
        [JsonProperty(PropertyName = "empFirstNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpFirstNameId { 
            get { return _EmpFirstNameId; }
            set { if(_EmpFirstNameId != value) { _EmpFirstNameId = value; OnPropertyChanged(); } }
        }
        protected System.String  _EmpFirstName;
        [JsonProperty(PropertyName = "empFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpFirstName { 
            get { return _EmpFirstName; }
            set { if(_EmpFirstName != value) { _EmpFirstName = value; OnPropertyChanged(); } }
        }
    }
}

