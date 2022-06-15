using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LpPhBkEntity.PhBk
{
    public class LpdEmpLastName
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Id of the Row", Prompt = "Enter Row Id", ShortName = "Row Id")]
        [Required]
        public int EmpLastNameId { get; set; }

        [Display(Description = "Last Name of the Employee", Name = "Employee Last Name", Prompt = "Enter Employee Last Name", ShortName = "Last Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Required]
        public string EmpLastName { get; set; } = null!;

        public List<LprEmployee01> EmployeeRef01 { get; set; } = null!;
        public List<LprEmployee02> EmployeeRef02 { get; set; } = null!;
    }
}
