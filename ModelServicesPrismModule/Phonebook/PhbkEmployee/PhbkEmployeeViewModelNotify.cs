using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;

namespace ModelServicesPrismModule.Phonebook.PhbkEmployee {
    public class PhbkEmployeeViewNotify: IPhbkEmployeeViewNotify
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
            + _EmpFirstName
            + _EmpLastName
            + _EmpSecondName
            + _DivisionIdRef
            + _DDivisionName
            + _DEEntrprsName
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
        protected System.String  _EmpFirstName;
        [JsonProperty(PropertyName = "empFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpFirstName { 
            get { return _EmpFirstName; }
            set { if(_EmpFirstName != value) { _EmpFirstName = value; OnPropertyChanged(); } }
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
        protected System.String  _EmpSecondName;
        [JsonProperty(PropertyName = "empSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        public System.String  EmpSecondName { 
            get { return _EmpSecondName; }
            set { if(_EmpSecondName != value) { _EmpSecondName = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _DivisionIdRef;
        [JsonProperty(PropertyName = "divisionIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionIdRef { 
            get { return _DivisionIdRef; }
            set { if(_DivisionIdRef != value) { _DivisionIdRef = value; OnPropertyChanged(); } }
        }
        protected System.String  _DDivisionName;
        [JsonProperty(PropertyName = "dDivisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DDivisionName { 
            get { return _DDivisionName; }
            set { if(_DDivisionName != value) { _DDivisionName = value; OnPropertyChanged(); } }
        }
        protected System.String  _DEEntrprsName;
        [JsonProperty(PropertyName = "dEEntrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DEEntrprsName { 
            get { return _DEEntrprsName; }
            set { if(_DEEntrprsName != value) { _DEEntrprsName = value; OnPropertyChanged(); } }
        }
    }
}

