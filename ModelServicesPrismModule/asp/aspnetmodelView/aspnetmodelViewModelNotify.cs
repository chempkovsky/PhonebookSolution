using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;

namespace ModelServicesPrismModule.asp.aspnetmodelView {
    public class AspnetmodelViewNotify: IAspnetmodelViewNotify
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
            + _ModelPk
            + _ModelName
            + _ModelDescription
            ;
        }

        protected System.Int32  _ModelPk;
        [JsonProperty(PropertyName = "modelPk")]
        [Required]
        [Display(Description="Model Id",Name="Model Id",Prompt="Enter Model Id",ShortName="Id")]
        public System.Int32  ModelPk { 
            get { return _ModelPk; }
            set { if(_ModelPk != value) { _ModelPk = value; OnPropertyChanged(); } }
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
        protected System.String  _ModelDescription;
        [JsonProperty(PropertyName = "modelDescription")]
        [Display(Description="Model Description",Name="Model Description",Prompt="Enter ModelDescription",ShortName="Description")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  ModelDescription { 
            get { return _ModelDescription; }
            set { if(_ModelDescription != value) { _ModelDescription = value; OnPropertyChanged(); } }
        }
    }
}

