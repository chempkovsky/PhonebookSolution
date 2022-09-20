using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserpermsView;

namespace ModelServicesPrismModule.asp.aspnetuserpermsView {
    public class AspnetuserpermsViewNotify: IAspnetuserpermsViewNotify
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
            + _ModelName
            + _UserPerms
            ;
        }

        protected System.String  _ModelName;
        [JsonProperty(PropertyName = "modelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  ModelName { 
            get { return _ModelName; }
            set { if(_ModelName != value) { _ModelName = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _UserPerms;
        [JsonProperty(PropertyName = "userPerms")]
        [Required]
        [Display(Description="User Perms",Name="User Perms",Prompt="Enter User Perms",ShortName="User Perms")]
        public System.Int32  UserPerms { 
            get { return _UserPerms; }
            set { if(_UserPerms != value) { _UserPerms = value; OnPropertyChanged(); } }
        }
    }
}

