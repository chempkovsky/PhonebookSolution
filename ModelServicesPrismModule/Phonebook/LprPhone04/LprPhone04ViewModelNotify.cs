using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprPhone04;

namespace ModelServicesPrismModule.Phonebook.LprPhone04 {
    public class LprPhone04ViewNotify: ILprPhone04ViewNotify
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
            + _LpdPhoneIdRef
            + _EmployeeIdRef
            + _PhoneTypeIdRef
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
        protected System.Int32  _LpdPhoneIdRef;
        [JsonProperty(PropertyName = "lpdPhoneIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  LpdPhoneIdRef { 
            get { return _LpdPhoneIdRef; }
            set { if(_LpdPhoneIdRef != value) { _LpdPhoneIdRef = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EmployeeIdRef;
        [JsonProperty(PropertyName = "employeeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeIdRef { 
            get { return _EmployeeIdRef; }
            set { if(_EmployeeIdRef != value) { _EmployeeIdRef = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _PhoneTypeIdRef;
        [JsonProperty(PropertyName = "phoneTypeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        public System.Int32  PhoneTypeIdRef { 
            get { return _PhoneTypeIdRef; }
            set { if(_PhoneTypeIdRef != value) { _PhoneTypeIdRef = value; OnPropertyChanged(); } }
        }
    }
}

