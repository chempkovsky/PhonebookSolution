using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView {
    public interface IAspnetuserView
    {
        [JsonProperty(PropertyName = "id")]
        [Required]
        [Display(Description="User Id",Name="User Id",Prompt="Enter Id",ShortName="User Id")]
        [StringLength(128,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        [Display(Description="User Email",Name="User Email",Prompt="Enter Email",ShortName="User Email")]
        [StringLength(256,MinimumLength=0,ErrorMessage="Invalid")]
        System.String  Email { get; set; }

        [JsonProperty(PropertyName = "emailConfirmed")]
        [Required]
        [Display(Description="Email Confirmed",Name="Email Confirmed",Prompt="Enter Email Confirmed",ShortName="Email Confirmed")]
        System.Boolean  EmailConfirmed { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        [Display(Description="Phone Number",Name="Phone Number",Prompt="Enter Phone Number",ShortName="Phone Number")]
        System.String  PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "phoneNumberConfirmed")]
        [Required]
        [Display(Description="Phone Number Confirmed",Name="Phone Number Confirmed",Prompt="Enter Phone Number Confirmed",ShortName="Phone Number Confirmed")]
        System.Boolean  PhoneNumberConfirmed { get; set; }

        [JsonProperty(PropertyName = "twoFactorEnabled")]
        [Required]
        [Display(Description="Two Factor Enabled",Name="Two Factor Enabled",Prompt="Enter Two Factor Enabled",ShortName="Two Factor Enabled")]
        System.Boolean  TwoFactorEnabled { get; set; }

        [JsonProperty(PropertyName = "lockoutEnd")]
        [Display(Description="Lockout End",Name="Lockout End",Prompt="Enter Lockout",ShortName="Lockout End")]
        System.DateTimeOffset ?  LockoutEnd { get; set; }

        [JsonProperty(PropertyName = "lockoutEnabled")]
        [Required]
        [Display(Description="Lockout Enabled",Name="Lockout Enabled",Prompt="Enter Lockout Enabled",ShortName="Lockout Enabled")]
        System.Boolean  LockoutEnabled { get; set; }

        [JsonProperty(PropertyName = "accessFailedCount")]
        [Required]
        [Display(Description="Access Failed Count",Name="Access Failed Count",Prompt="Enter Access Failed Count",ShortName="Access Failed Count")]
        System.Int32  AccessFailedCount { get; set; }

        [JsonProperty(PropertyName = "userName")]
        [Display(Description="User Name",Name="User Name",Prompt="Enter User Name",ShortName="User Name")]
        [StringLength(256,MinimumLength=1,ErrorMessage="Invalid")]
        System.String  UserName { get; set; }

    }
}

