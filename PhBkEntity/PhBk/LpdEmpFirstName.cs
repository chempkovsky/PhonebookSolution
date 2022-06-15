#if (!NOTMODELING)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class LpdEmpFirstName
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Id of the Row", Prompt = "Enter Row Id", ShortName = "Row Id")]
        [Required]
        public int EmpFirstNameId { get; set; }

        [Display(Description = "First Name of the Employee", Name = "Employee First Name", Prompt = "Enter Employee First Name", ShortName = "First Name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Required]
        public string EmpFirstName { get; set; } = null!;

        public List<LprEmployee01> EmployeeRef01 { get; set; } = null!;
        public List<LprEmployee02> EmployeeRef02 { get; set; } = null!;

    }
}
#endif
