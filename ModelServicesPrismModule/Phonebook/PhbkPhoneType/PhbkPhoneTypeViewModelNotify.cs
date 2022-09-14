using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkPhoneType;

namespace ModelServicesPrismModule.Phonebook.PhbkPhoneType {
    public class PhbkPhoneTypeViewNotify: IPhbkPhoneTypeViewNotify
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
            + _PhoneTypeId
            + _PhoneTypeName
            + _PhoneTypeDesc
            ;
        }

        protected System.Int32  _PhoneTypeId;
        [JsonProperty(PropertyName = "phoneTypeId")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        public System.Int32  PhoneTypeId { 
            get { return _PhoneTypeId; }
            set { if(_PhoneTypeId != value) { _PhoneTypeId = value; OnPropertyChanged(); } }
        }
        protected System.String  _PhoneTypeName;
        [JsonProperty(PropertyName = "phoneTypeName")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone Type Name",Prompt="Enter Phone Type Name",ShortName="Phone Type Name")]
        public System.String  PhoneTypeName { 
            get { return _PhoneTypeName; }
            set { if(_PhoneTypeName != value) { _PhoneTypeName = value; OnPropertyChanged(); } }
        }
        protected System.String  _PhoneTypeDesc;
        [JsonProperty(PropertyName = "phoneTypeDesc")]
        [Display(Description="Description of the Phone Type",Name="Phone Type Description",Prompt="Enter Phone Type Description",ShortName="Phone Type Description")]
        [StringLength(250,ErrorMessage="Invalid")]
        public System.String  PhoneTypeDesc { 
            get { return _PhoneTypeDesc; }
            set { if(_PhoneTypeDesc != value) { _PhoneTypeDesc = value; OnPropertyChanged(); } }
        }
    }
}

