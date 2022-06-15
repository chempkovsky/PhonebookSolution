using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class PhbkDivision
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row id", Name = "Id of the Division", Prompt = "Enter Division Id", ShortName = "Division Id")]
        [Required]
        public int DivisionId { get; set; }

        [Display(Description = "Name of the Enterprise Division", Name = "Name of the Division", Prompt = "Enter Division Name", ShortName = "Division Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Required]
        public string DivisionName { get; set; } = null!;

        [Display(Description = "Description of the Enterprise Division", Name = "Description of the Division", Prompt = "Enter Enterprise Division Description", ShortName = "Division Description")]
        [StringLength(250, ErrorMessage = "Invalid")]
        public string? DivisionDesc { get; set; }

        [Display(Description = "Row id", Name = "Id of the Enterprise", Prompt = "Enter Enterprise  Id", ShortName = "Enterprise Id")]
        [Required]
        public int EntrprsIdRef { get; set; }

        public PhbkEnterprise Enterprise { get; set; } = null!;

        public List<PhbkEmployee> Employees { get; set; } = null!;

#if (!NOTMODELING)
        public List<LprDivision01> DivisionRefs01 { get; set; } = null!;
        public List<LprDivision02> DivisionRefs02 { get; set; } = null!;
        public List<LprEmployee02> EmployeeRefs02 { get; set; } = null!;
#endif
    }
}
