

using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace PhBkViews.AspNetReg
{
    public class changepasswordbindingmodel
    {

        [Required]
        [JsonPropertyName("oldpassword")]
        public string OldPassword { get; set; } = null!;

        [Required]
        [JsonPropertyName("newPassword")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; } = null!;

        [Required]
        [JsonPropertyName("confirmPassword")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

    }
}


