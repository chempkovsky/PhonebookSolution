

using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace PhBkViews.AspNetReg
{
    public class loginbindingmodel
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;

        
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; } = null!;
    }
}


