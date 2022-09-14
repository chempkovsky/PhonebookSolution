using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee02;

namespace ModelServicesPrismModule.Phonebook.LprEmployee02 {
    public class LprEmployee02ViewNotify: ILprEmployee02ViewNotify
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
            + _DivisionIdRef
            ;
        }

        protected System.Int32  _EmployeeId;
        [JsonProperty(PropertyName = "employeeId")]
        [Required]
        [Display(Description="Emp Row id",Name="Id of the Employee",Prompt="Enter Employee Id",ShortName="Employee Id")]
        public System.Int32  EmployeeId { 
            get { return _EmployeeId; }
            set { if(_EmployeeId != value) { _EmployeeId = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EmpLastNameIdRef;
        [JsonProperty(PropertyName = "empLastNameIdRef")]
        [Required]
        [Display(Description="Lst name ref id",Name="Lst name  ref Id",Prompt="Enter Lst name ref Id",ShortName="Lst name ref Id")]
        public System.Int32  EmpLastNameIdRef { 
            get { return _EmpLastNameIdRef; }
            set { if(_EmpLastNameIdRef != value) { _EmpLastNameIdRef = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EmpFirstNameIdRef;
        [JsonProperty(PropertyName = "empFirstNameIdRef")]
        [Required]
        [Display(Description="Frst name ref id",Name="Frst name  ref Id",Prompt="Enter Frst name ref Id",ShortName="Frst name ref Id")]
        public System.Int32  EmpFirstNameIdRef { 
            get { return _EmpFirstNameIdRef; }
            set { if(_EmpFirstNameIdRef != value) { _EmpFirstNameIdRef = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EmpSecondNameIdRef;
        [JsonProperty(PropertyName = "empSecondNameIdRef")]
        [Required]
        [Display(Description="Sec name ref id",Name="Sec name  ref Id",Prompt="Enter Sec name ref Id",ShortName="Sec name ref Id")]
        public System.Int32  EmpSecondNameIdRef { 
            get { return _EmpSecondNameIdRef; }
            set { if(_EmpSecondNameIdRef != value) { _EmpSecondNameIdRef = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _DivisionIdRef;
        [JsonProperty(PropertyName = "divisionIdRef")]
        [Required]
        [Display(Description="Division Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionIdRef { 
            get { return _DivisionIdRef; }
            set { if(_DivisionIdRef != value) { _DivisionIdRef = value; OnPropertyChanged(); } }
        }
    }
}

