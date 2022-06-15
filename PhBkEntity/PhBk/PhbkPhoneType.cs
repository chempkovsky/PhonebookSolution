using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class PhbkPhoneType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row id", Name = "Phone Type Id", Prompt = "Enter Phone Type Id", ShortName = "Phone Type Id")]
        [Required]
        public int PhoneTypeId { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Display(Description = "Name of the Phone Type", Name = "Phone Type Name", Prompt = "Enter Phone Type Name", ShortName = "Phone Type Name")]
        [Required]
        public string PhoneTypeName { get; set; } = null!;

        [Display(Description = "Description of the Phone Type", Name = "Phone Type Description", Prompt = "Enter Phone Type Description", ShortName = "Phone Type Description")]
        [StringLength(250, ErrorMessage = "Invalid")]
        public string? PhoneTypeDesc { get; set; }

        public List<PhbkPhone> Phones { get; set; } = null!;

#if (!NOTMODELING)
        public List<LprPhone03> PhoneRefs03 { get; set; } = null!;
        public List<LprPhone04> PhoneRefs04 { get; set; } = null!;
#endif


    }
}
