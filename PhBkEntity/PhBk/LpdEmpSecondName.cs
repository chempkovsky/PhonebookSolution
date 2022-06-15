#if (!NOTMODELING)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class LpdEmpSecondName
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Id of the Row", Prompt = "Enter Row Id", ShortName = "Row Id")]
        [Required]
        public int EmpSecondNameId { get; set; }

        [Display(Description = "Row id", Name = "Employee Second Name", Prompt = "Enter Employee Second Name", ShortName = "Second Name")]
        [StringLength(25, ErrorMessage = "Invalid")]
        public string EmpSecondName { get; set; } = string.Empty;

        public List<LprEmployee01> EmployeeRef01 { get; set; } = null!;
        public List<LprEmployee02> EmployeeRef02 { get; set; } = null!;
    }
}
#endif
