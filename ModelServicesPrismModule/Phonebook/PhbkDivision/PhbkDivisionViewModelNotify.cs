using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.PhbkDivision;

namespace ModelServicesPrismModule.Phonebook.PhbkDivision {
    public class PhbkDivisionViewNotify: IPhbkDivisionViewNotify
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
            + _DivisionId
            + _DivisionName
            + _DivisionDesc
            + _EntrprsIdRef
            + _EEntrprsName
            ;
        }

        protected System.Int32  _DivisionId;
        [JsonProperty(PropertyName = "divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionId { 
            get { return _DivisionId; }
            set { if(_DivisionId != value) { _DivisionId = value; OnPropertyChanged(); } }
        }
        protected System.String  _DivisionName;
        [JsonProperty(PropertyName = "divisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DivisionName { 
            get { return _DivisionName; }
            set { if(_DivisionName != value) { _DivisionName = value; OnPropertyChanged(); } }
        }
        protected System.String  _DivisionDesc;
        [JsonProperty(PropertyName = "divisionDesc")]
        [Display(Description="Description of the Enterprise Division",Name="Description of the Division",Prompt="Enter Enterprise Division Description",ShortName="Division Description")]
        [StringLength(250,ErrorMessage="Invalid")]
        public System.String  DivisionDesc { 
            get { return _DivisionDesc; }
            set { if(_DivisionDesc != value) { _DivisionDesc = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _EntrprsIdRef;
        [JsonProperty(PropertyName = "entrprsIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        public System.Int32  EntrprsIdRef { 
            get { return _EntrprsIdRef; }
            set { if(_EntrprsIdRef != value) { _EntrprsIdRef = value; OnPropertyChanged(); } }
        }
        protected System.String  _EEntrprsName;
        [JsonProperty(PropertyName = "eEntrprsName")]
        [Required]
        [Display(Description="Name of the Enterprise",Name="Name of the Enterprise",Prompt="Enter Enterprise Name",ShortName="Enterprise Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EEntrprsName { 
            get { return _EEntrprsName; }
            set { if(_EEntrprsName != value) { _EEntrprsName = value; OnPropertyChanged(); } }
        }
    }
}

