using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;

namespace ModelServicesPrismModule.asp.aspnetroleView {
    public class AspnetroleViewNotify: IAspnetroleViewNotify
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
            + _Id
            + _Name
            ;
        }

        protected System.String  _Id;
        [JsonProperty(PropertyName = "id")]
        [Required]
        [Display(Description="Role Id",Name="Role Id",Prompt="Enter Id",ShortName="Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  Id { 
            get { return _Id; }
            set { if(_Id != value) { _Id = value; OnPropertyChanged(); } }
        }
        protected System.String  _Name;
        [JsonProperty(PropertyName = "name")]
        [Required]
        [Display(Description="Role Name",Name="Role Name",Prompt="Enter RoleName",ShortName="Role Name")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  Name { 
            get { return _Name; }
            set { if(_Name != value) { _Name = value; OnPropertyChanged(); } }
        }
    }
}

