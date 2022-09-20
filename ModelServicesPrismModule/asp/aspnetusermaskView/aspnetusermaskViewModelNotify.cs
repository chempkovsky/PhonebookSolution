using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetusermaskView;

namespace ModelServicesPrismModule.asp.aspnetusermaskView {
    public class AspnetusermaskViewNotify: IAspnetusermaskViewNotify
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
            + _UserId
            + _Mask1
            + _Mask2
            + _Mask3
            + _Mask4
            + _Mask5
            + _ModelPkRef
            + _UEmail
            + _UUserName
            + _MModelName
            ;
        }

        protected System.String  _UserId;
        [JsonProperty(PropertyName = "userId")]
        [Required]
        [Display(Description="User Id",Name="User Id",Prompt="Enter Id",ShortName="User Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  UserId { 
            get { return _UserId; }
            set { if(_UserId != value) { _UserId = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _Mask1;
        [JsonProperty(PropertyName = "mask1")]
        [Required]
        [Display(Description="Permission to Sel",Name="Permission to Sel",Prompt="Enter permission to Sel",ShortName="Sel")]
        public System.Boolean  Mask1 { 
            get { return _Mask1; }
            set { if(_Mask1 != value) { _Mask1 = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _Mask2;
        [JsonProperty(PropertyName = "mask2")]
        [Required]
        [Display(Description="Permission to Del",Name="Permission to Del",Prompt="Enter permission to Del",ShortName="Del")]
        public System.Boolean  Mask2 { 
            get { return _Mask2; }
            set { if(_Mask2 != value) { _Mask2 = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _Mask3;
        [JsonProperty(PropertyName = "mask3")]
        [Required]
        [Display(Description="Permission to Upd",Name="Permission to Upd",Prompt="Enter permission to Upd",ShortName="Upd")]
        public System.Boolean  Mask3 { 
            get { return _Mask3; }
            set { if(_Mask3 != value) { _Mask3 = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _Mask4;
        [JsonProperty(PropertyName = "mask4")]
        [Required]
        [Display(Description="Permission to Add",Name="Permission to Add",Prompt="Enter permission to Add",ShortName="Add")]
        public System.Boolean  Mask4 { 
            get { return _Mask4; }
            set { if(_Mask4 != value) { _Mask4 = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _Mask5;
        [JsonProperty(PropertyName = "mask5")]
        [Required]
        [Display(Description="Full scan permission",Name="Full scan permission",Prompt="Enter Full scan permission",ShortName="FullScan")]
        public System.Boolean  Mask5 { 
            get { return _Mask5; }
            set { if(_Mask5 != value) { _Mask5 = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _ModelPkRef;
        [JsonProperty(PropertyName = "modelPkRef")]
        [Required]
        [Display(Description="Model Id",Name="Model Id",Prompt="Enter Model Id",ShortName="Id")]
        public System.Int32  ModelPkRef { 
            get { return _ModelPkRef; }
            set { if(_ModelPkRef != value) { _ModelPkRef = value; OnPropertyChanged(); } }
        }
        protected System.String  _UEmail;
        [JsonProperty(PropertyName = "uEmail")]
        [Display(Description="User Email",Name="User Email",Prompt="Enter Email",ShortName="User Email")]
        [StringLength(256,MinimumLength=0,ErrorMessage="Invalid")]
        public System.String  UEmail { 
            get { return _UEmail; }
            set { if(_UEmail != value) { _UEmail = value; OnPropertyChanged(); } }
        }
        protected System.String  _UUserName;
        [JsonProperty(PropertyName = "uUserName")]
        [Display(Description="User Name",Name="User Name",Prompt="Enter User Name",ShortName="User Name")]
        [StringLength(256,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  UUserName { 
            get { return _UUserName; }
            set { if(_UUserName != value) { _UUserName = value; OnPropertyChanged(); } }
        }
        protected System.String  _MModelName;
        [JsonProperty(PropertyName = "mModelName")]
        [Required]
        [Display(Description="Model Name",Name="Model Name",Prompt="Enter ModelName",ShortName="Name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  MModelName { 
            get { return _MModelName; }
            set { if(_MModelName != value) { _MModelName = value; OnPropertyChanged(); } }
        }
    }
}

