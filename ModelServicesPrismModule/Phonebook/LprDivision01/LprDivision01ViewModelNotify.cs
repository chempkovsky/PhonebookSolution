using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.Phonebook.LprDivision01;

namespace ModelServicesPrismModule.Phonebook.LprDivision01 {
    public class LprDivision01ViewNotify: ILprDivision01ViewNotify
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
            + _DivisionNameIdRef
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
        protected System.Int32  _DivisionNameIdRef;
        [JsonProperty(PropertyName = "divisionNameIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionNameIdRef { 
            get { return _DivisionNameIdRef; }
            set { if(_DivisionNameIdRef != value) { _DivisionNameIdRef = value; OnPropertyChanged(); } }
        }
    }
}

