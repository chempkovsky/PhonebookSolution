using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class PhbkEmployee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Id of the Employee", Prompt = "Enter Employee  Id", ShortName = "Employee Id")]
        [Required]
        public int EmployeeId { get; set; }

        [Display(Description = "First Name of the Employee", Name = "Employee First Name", Prompt = "Enter Employee First Name", ShortName = "First Name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Required]
        public string EmpFirstName { get; set; } = null!;

        [Display(Description = "Last Name of the Employee", Name = "Employee Last Name", Prompt = "Enter Employee Last Name", ShortName = "Last Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Required]
        public string EmpLastName { get; set; } = null!;

        [Display(Description = "Row id", Name = "Employee Second Name", Prompt = "Enter Employee Second Name", ShortName = "Second Name")]
        [StringLength(25, ErrorMessage = "Invalid")]
        public string? EmpSecondName { get; set; }

        [Display(Description = "Row id", Name = "Id of the Division", Prompt = "Enter Division Id", ShortName = "Division Id")]
        [Required]
        public int DivisionIdRef { get; set; }

        public PhbkDivision Division { get; set; } = null!;

        public List<PhbkPhone> Phones { get; set; } = null!;


#if (!NOTMODELING)
        public List<LprEmployee01> EmployeeRefs01 { get; set; } = null!;
        public List<LprEmployee02> EmployeeRefs02 { get; set; } = null!;
        public List<LprPhone02> PhoneRefs02 { get; set; } = null!;
        public List<LprPhone04> PhoneRefs04 { get; set; } = null!;
#endif

    }
}
