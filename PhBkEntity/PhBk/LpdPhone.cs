#if (!NOTMODELING)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class LpdPhone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Id of the Row", Prompt = "Enter Row Id", ShortName = "Row Id")]
        [Required]
        public int LpdPhoneId { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Display(Description = "Name of the Phone Type", Name = "Phone", Prompt = "Enter Phone", ShortName = "Phone")]
        [Required]
        public string Phone { get; set; } = null!;

        public List<LprPhone01> PhoneRef01 { get; set; } = null!;
        public List<LprPhone02> PhoneRef02 { get; set; } = null!;
        public List<LprPhone03> PhoneRef03 { get; set; } = null!;
        public List<LprPhone04> PhoneRef04 { get; set; } = null!;

    }
}
#endif