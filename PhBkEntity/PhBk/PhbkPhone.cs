using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class PhbkPhone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Phone Id", Prompt = "Enter Phone Id", ShortName = "Phone Id")]
        [Required]
        public int PhoneId { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Display(Description = "Name of the Phone Type", Name = "Phone", Prompt = "Enter Phone", ShortName = "Phone")]
        [Required]
        public string Phone { get; set; } = null!;

        [Display(Description = "Row id", Name = "Phone Type Id", Prompt = "Enter Phone Type Id", ShortName = "Phone Type Id")]
        [Required]
        public int PhoneTypeIdRef { get; set; }

        public PhbkPhoneType PhoneType { get; set; } = null!;


        [Display(Description = "Row id", Name = "Id of the Employee", Prompt = "Enter Employee  Id", ShortName = "Employee Id")]
        [Required]
        public int EmployeeIdRef { get; set; }

        public PhbkEmployee Employee { get; set; } = null!;

#if (!NOTMODELING)
        public List<LprPhone01> PhoneRefs01 { get; set; } = null!;
        public List<LprPhone02> PhoneRefs02 { get; set; } = null!;
        public List<LprPhone03> PhoneRefs03 { get; set; } = null!;
        public List<LprPhone04> PhoneRefs04 { get; set; } = null!;
#endif

    }
}
