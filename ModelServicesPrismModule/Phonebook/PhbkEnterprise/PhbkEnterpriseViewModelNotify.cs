using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkEnterprise;

namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise {
    public class PhbkEnterpriseViewNotify: IPhbkEnterpriseViewNotify
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
            + _EntrprsId
            + _EntrprsName
            + _EntrprsDesc
            ;
        }

        protected System.Int32  _EntrprsId;
        [JsonProperty(PropertyName = "entrprsId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        public System.Int32  EntrprsId { 
            get { return _EntrprsId; }
            set { if(_EntrprsId != value) { _EntrprsId = value; OnPropertyChanged(); } }
        }
        protected System.String  _EntrprsName;
        [JsonProperty(PropertyName = "entrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EntrprsName { 
            get { return _EntrprsName; }
            set { if(_EntrprsName != value) { _EntrprsName = value; OnPropertyChanged(); } }
        }
        protected System.String  _EntrprsDesc;
        [JsonProperty(PropertyName = "entrprsDesc")]
        [Display(Description="Description of the Enterprise",Name="Description of the Enterprise",Prompt="Description Enterprise Name",ShortName="Enterprise Description")]
        [StringLength(250,ErrorMessage="Invalid")]
        public System.String  EntrprsDesc { 
            get { return _EntrprsDesc; }
            set { if(_EntrprsDesc != value) { _EntrprsDesc = value; OnPropertyChanged(); } }
        }
    }
}

