using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView;

namespace ModelServicesPrismModule.asp.aspnetuserView {
    public class AspnetuserViewNotify: IAspnetuserViewNotify
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
            + _Email
            + _EmailConfirmed
            + _PhoneNumber
            + _PhoneNumberConfirmed
            + _TwoFactorEnabled
            + _LockoutEnd
            + _LockoutEnabled
            + _AccessFailedCount
            + _UserName
            ;
        }

        protected System.String  _Id;
        [JsonProperty(PropertyName = "id")]
        [Required]
        [Display(Description="User Id",Name="User Id",Prompt="Enter Id",ShortName="User Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  Id { 
            get { return _Id; }
            set { if(_Id != value) { _Id = value; OnPropertyChanged(); } }
        }
        protected System.String  _Email;
        [JsonProperty(PropertyName = "email")]
        [Display(Description="User Email",Name="User Email",Prompt="Enter Email",ShortName="User Email")]
        [StringLength(256,MinimumLength=0,ErrorMessage="Invalid")]
        public System.String  Email { 
            get { return _Email; }
            set { if(_Email != value) { _Email = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _EmailConfirmed;
        [JsonProperty(PropertyName = "emailConfirmed")]
        [Required]
        [Display(Description="Email Confirmed",Name="Email Confirmed",Prompt="Enter Email Confirmed",ShortName="Email Confirmed")]
        public System.Boolean  EmailConfirmed { 
            get { return _EmailConfirmed; }
            set { if(_EmailConfirmed != value) { _EmailConfirmed = value; OnPropertyChanged(); } }
        }
        protected System.String  _PhoneNumber;
        [JsonProperty(PropertyName = "phoneNumber")]
        [Display(Description="Phone Number",Name="Phone Number",Prompt="Enter Phone Number",ShortName="Phone Number")]
        public System.String  PhoneNumber { 
            get { return _PhoneNumber; }
            set { if(_PhoneNumber != value) { _PhoneNumber = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _PhoneNumberConfirmed;
        [JsonProperty(PropertyName = "phoneNumberConfirmed")]
        [Required]
        [Display(Description="Phone Number Confirmed",Name="Phone Number Confirmed",Prompt="Enter Phone Number Confirmed",ShortName="Phone Number Confirmed")]
        public System.Boolean  PhoneNumberConfirmed { 
            get { return _PhoneNumberConfirmed; }
            set { if(_PhoneNumberConfirmed != value) { _PhoneNumberConfirmed = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _TwoFactorEnabled;
        [JsonProperty(PropertyName = "twoFactorEnabled")]
        [Required]
        [Display(Description="Two Factor Enabled",Name="Two Factor Enabled",Prompt="Enter Two Factor Enabled",ShortName="Two Factor Enabled")]
        public System.Boolean  TwoFactorEnabled { 
            get { return _TwoFactorEnabled; }
            set { if(_TwoFactorEnabled != value) { _TwoFactorEnabled = value; OnPropertyChanged(); } }
        }
        protected System.DateTimeOffset ?  _LockoutEnd;
        [JsonProperty(PropertyName = "lockoutEnd")]
        [Display(Description="Lockout End",Name="Lockout End",Prompt="Enter Lockout",ShortName="Lockout End")]
        public System.DateTimeOffset ?  LockoutEnd { 
            get { return _LockoutEnd; }
            set { if(_LockoutEnd != value) { _LockoutEnd = value; OnPropertyChanged(); } }
        }
        protected System.Boolean  _LockoutEnabled;
        [JsonProperty(PropertyName = "lockoutEnabled")]
        [Required]
        [Display(Description="Lockout Enabled",Name="Lockout Enabled",Prompt="Enter Lockout Enabled",ShortName="Lockout Enabled")]
        public System.Boolean  LockoutEnabled { 
            get { return _LockoutEnabled; }
            set { if(_LockoutEnabled != value) { _LockoutEnabled = value; OnPropertyChanged(); } }
        }
        protected System.Int32  _AccessFailedCount;
        [JsonProperty(PropertyName = "accessFailedCount")]
        [Required]
        [Display(Description="Access Failed Count",Name="Access Failed Count",Prompt="Enter Access Failed Count",ShortName="Access Failed Count")]
        public System.Int32  AccessFailedCount { 
            get { return _AccessFailedCount; }
            set { if(_AccessFailedCount != value) { _AccessFailedCount = value; OnPropertyChanged(); } }
        }
        protected System.String  _UserName;
        [JsonProperty(PropertyName = "userName")]
        [Display(Description="User Name",Name="User Name",Prompt="Enter User Name",ShortName="User Name")]
        [StringLength(256,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  UserName { 
            get { return _UserName; }
            set { if(_UserName != value) { _UserName = value; OnPropertyChanged(); } }
        }
    }
}

