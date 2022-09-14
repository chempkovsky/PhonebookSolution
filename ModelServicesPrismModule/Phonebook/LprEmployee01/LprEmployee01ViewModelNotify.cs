using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee01;

namespace ModelServicesPrismModule.Phonebook.LprEmployee01 {
    public class LprEmployee01ViewNotify: ILprEmployee01ViewNotify
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
            + _EmployeeId
            + _EmpLastNameIdRef
            + _EmpFirstNameIdRef
            + _EmpSecondNameIdRef
            ;
        }

        protected System.Int32  _EmployeeId;
        [JsonProperty(PropertyName = "employeeId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeId { 
            get { return _EmployeeId; }
            set { if(_EmployeeId != value) { _EmployeeId = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EmpLastNameIdRef;
        [JsonProperty(PropertyName = "empLastNameIdRef")]
        [Required]
        [Display(Description="Row ref id",Name="ref Id of the Row",Prompt="Enter Row ref Id",ShortName="Row ref Id")]
        public System.Int32  EmpLastNameIdRef { 
            get { return _EmpLastNameIdRef; }
            set { if(_EmpLastNameIdRef != value) { _EmpLastNameIdRef = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EmpFirstNameIdRef;
        [JsonProperty(PropertyName = "empFirstNameIdRef")]
        [Required]
        [Display(Description="Row ref id",Name="ref Id of the Row",Prompt="Enter Row ref Id",ShortName="Row ref Id")]
        public System.Int32  EmpFirstNameIdRef { 
            get { return _EmpFirstNameIdRef; }
            set { if(_EmpFirstNameIdRef != value) { _EmpFirstNameIdRef = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EmpSecondNameIdRef;
        [JsonProperty(PropertyName = "empSecondNameIdRef")]
        [Required]
        [Display(Description="S name ref id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  EmpSecondNameIdRef { 
            get { return _EmpSecondNameIdRef; }
            set { if(_EmpSecondNameIdRef != value) { _EmpSecondNameIdRef = value; OnPropertyChanged(); } }
        }
    }
}

