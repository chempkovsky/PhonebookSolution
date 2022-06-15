#if (!NOTMODELING)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class LprPhone03
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Phone Id", Prompt = "Enter Phone Id", ShortName = "Phone Id")]
        [Required]
        public int PhoneId { get; set; }
        public PhbkPhone Phone { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Id of the Row", Prompt = "Enter Row Id", ShortName = "Row Id")]
        [Required]
        public int LpdPhoneIdRef { get; set; }

        public LpdPhone PhoneDict { get; set; } = null!;

        [Display(Description = "Row id", Name = "Phone Type Id", Prompt = "Enter Phone Type Id", ShortName = "Phone Type Id")]
        [Required]
        public int PhoneTypeIdRef { get; set; }

        public PhbkPhoneType PhoneType { get; set; } = null!;
    }
}
#endif