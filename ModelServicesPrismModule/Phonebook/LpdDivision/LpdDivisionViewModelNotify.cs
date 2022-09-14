using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LpdDivision;

namespace ModelServicesPrismModule.Phonebook.LpdDivision {
    public class LpdDivisionViewNotify: ILpdDivisionViewNotify
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
            + _DivisionNameId
            + _DivisionName
            ;
        }

        protected System.Int32  _DivisionNameId;
        [JsonProperty(PropertyName = "divisionNameId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Row",Prompt="Enter Row Id",ShortName="Row Id")]
        public System.Int32  DivisionNameId { 
            get { return _DivisionNameId; }
            set { if(_DivisionNameId != value) { _DivisionNameId = value; OnPropertyChanged(); } }
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
    }
}

