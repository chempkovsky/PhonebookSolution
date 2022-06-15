

using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace PhBkViews.AspNetReg
{
    public class registerbindingmodel
    {

        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [Required]
        [JsonPropertyName("password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Required]
        [JsonPropertyName("confirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

    }
}


