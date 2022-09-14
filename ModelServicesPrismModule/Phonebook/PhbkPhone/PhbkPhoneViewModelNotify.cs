using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;

namespace ModelServicesPrismModule.Phonebook.PhbkPhone {
    public class PhbkPhoneViewNotify: IPhbkPhoneViewNotify
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
            + _PhoneId
            + _Phone
            + _PhoneTypeIdRef
            + _EmployeeIdRef
            + _PPhoneTypeName
            + _EEmpFirstName
            + _EEmpLastName
            + _EEmpSecondName
            + _EDDivisionName
            + _EDEEntrprsName
            ;
        }

        protected System.Int32  _PhoneId;
        [JsonProperty(PropertyName = "phoneId")]
        [Required]
        [Display(Description="Row id",Name="Phone Id",Prompt="Enter Phone Id",ShortName="Phone Id")]
        public System.Int32  PhoneId { 
            get { return _PhoneId; }
            set { if(_PhoneId != value) { _PhoneId = value; OnPropertyChanged(); } }
        }
        protected System.String  _Phone;
        [JsonProperty(PropertyName = "phone")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone",Prompt="Enter Phone",ShortName="Phone")]
        public System.String  Phone { 
            get { return _Phone; }
            set { if(_Phone != value) { _Phone = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _PhoneTypeIdRef;
        [JsonProperty(PropertyName = "phoneTypeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        public System.Int32  PhoneTypeIdRef { 
            get { return _PhoneTypeIdRef; }
            set { if(_PhoneTypeIdRef != value) { _PhoneTypeIdRef = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EmployeeIdRef;
        [JsonProperty(PropertyName = "employeeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeIdRef { 
            get { return _EmployeeIdRef; }
            set { if(_EmployeeIdRef != value) { _EmployeeIdRef = value; OnPropertyChanged(); } }
        }
        protected System.String  _PPhoneTypeName;
        [JsonProperty(PropertyName = "pPhoneTypeName")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone Type Name",Prompt="Enter Phone Type Name",ShortName="Phone Type Name")]
        public System.String  PPhoneTypeName { 
            get { return _PPhoneTypeName; }
            set { if(_PPhoneTypeName != value) { _PPhoneTypeName = value; OnPropertyChanged(); } }
        }
        protected System.String  _EEmpFirstName;
        [JsonProperty(PropertyName = "eEmpFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EEmpFirstName { 
            get { return _EEmpFirstName; }
            set { if(_EEmpFirstName != value) { _EEmpFirstName = value; OnPropertyChanged(); } }
        }
        protected System.String  _EEmpLastName;
        [JsonProperty(PropertyName = "eEmpLastName")]
        [Required]
        [Display(Description="Last Name of the Employee",Name="Employee Last Name",Prompt="Enter Employee Last Name",ShortName="Last Name")]
        [StringLength(40,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EEmpLastName { 
            get { return _EEmpLastName; }
            set { if(_EEmpLastName != value) { _EEmpLastName = value; OnPropertyChanged(); } }
        }
        protected System.String  _EEmpSecondName;
        [JsonProperty(PropertyName = "eEmpSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        public System.String  EEmpSecondName { 
            get { return _EEmpSecondName; }
            set { if(_EEmpSecondName != value) { _EEmpSecondName = value; OnPropertyChanged(); } }
        }
        protected System.String  _EDDivisionName;
        [JsonProperty(PropertyName = "eDDivisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EDDivisionName { 
            get { return _EDDivisionName; }
            set { if(_EDDivisionName != value) { _EDDivisionName = value; OnPropertyChanged(); } }
        }
        protected System.String  _EDEEntrprsName;
        [JsonProperty(PropertyName = "eDEEntrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EDEEntrprsName { 
            get { return _EDEEntrprsName; }
            set { if(_EDEEntrprsName != value) { _EDEEntrprsName = value; OnPropertyChanged(); } }
        }
    }
}

