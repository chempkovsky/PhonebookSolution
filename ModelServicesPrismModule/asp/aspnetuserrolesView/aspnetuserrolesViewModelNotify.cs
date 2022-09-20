using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView;

namespace ModelServicesPrismModule.asp.aspnetuserrolesView {
    public class AspnetuserrolesViewNotify: IAspnetuserrolesViewNotify
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
            + _RoleId
            + _ULockoutEnd
            + _UUserName
            + _RName
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
        protected System.String  _RoleId;
        [JsonProperty(PropertyName = "roleId")]
        [Required]
        [Display(Description="Role Id",Name="Role Id",Prompt="Enter Id",ShortName="Role Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  RoleId { 
            get { return _RoleId; }
            set { if(_RoleId != value) { _RoleId = value; OnPropertyChanged(); } }
        }
        protected System.DateTimeOffset ?  _ULockoutEnd;
        [JsonProperty(PropertyName = "uLockoutEnd")]
        [Display(Description="Lockout End",Name="Lockout End",Prompt="Enter Lockout",ShortName="Lockout End")]
        public System.DateTimeOffset ?  ULockoutEnd { 
            get { return _ULockoutEnd; }
            set { if(_ULockoutEnd != value) { _ULockoutEnd = value; OnPropertyChanged(); } }
        }
        protected System.String  _UUserName;
        [JsonProperty(PropertyName = "uUserName")]
        [Display(Description="User Name",Name="User Name",Prompt="Enter User Name",ShortName="User Name")]
        [StringLength(256,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  UUserName { 
            get { return _UUserName; }
            set { if(_UUserName != value) { _UUserName = value; OnPropertyChanged(); } }
        }
        protected System.String  _RName;
        [JsonProperty(PropertyName = "rName")]
        [Required]
        [Display(Description="Role Name",Name="Role Name",Prompt="Enter RoleName",ShortName="Role Name")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        public System.String  RName { 
            get { return _RName; }
            set { if(_RName != value) { _RName = value; OnPropertyChanged(); } }
        }
    }
}

