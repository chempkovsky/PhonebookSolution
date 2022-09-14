using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdPhone;

namespace ModelServicesPrismModule.Phonebook.LpdPhone {
    public class LpdPhoneViewNotify: ILpdPhoneViewNotify
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
            + _LpdPhoneId
            + _Phone
            ;
        }

        protected System.Int32  _LpdPhoneId;
        [JsonProperty(PropertyName = "lpdPhoneId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  LpdPhoneId { 
            get { return _LpdPhoneId; }
            set { if(_LpdPhoneId != value) { _LpdPhoneId = value; OnPropertyChanged(); } }
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
    }
}

