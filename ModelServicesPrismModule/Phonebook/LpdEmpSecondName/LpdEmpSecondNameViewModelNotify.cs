using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdEmpSecondName;

namespace ModelServicesPrismModule.Phonebook.LpdEmpSecondName {
    public class LpdEmpSecondNameViewNotify: ILpdEmpSecondNameViewNotify
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
            + _EmpSecondNameId
            + _EmpSecondName
            ;
        }

        protected System.Int32  _EmpSecondNameId;
        [JsonProperty(PropertyName = "empSecondNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpSecondNameId { 
            get { return _EmpSecondNameId; }
            set { if(_EmpSecondNameId != value) { _EmpSecondNameId = value; OnPropertyChanged(); } }
        }
        protected System.String  _EmpSecondName;
        [JsonProperty(PropertyName = "empSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        public System.String  EmpSecondName { 
            get { return _EmpSecondName; }
            set { if(_EmpSecondName != value) { _EmpSecondName = value; OnPropertyChanged(); } }
        }
    }
}

