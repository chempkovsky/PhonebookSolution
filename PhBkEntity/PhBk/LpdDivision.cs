#if (!NOTMODELING)

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class LpdDivision
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Description = "Row id", Name = "Id of the Row", Prompt = "Enter Row Id", ShortName = "Row Id")]
        [Required]
        public int DivisionNameId { get; set; }

        [Display(Description = "Name of the Enterprise Division", Name = "Name of the Division", Prompt = "Enter Division Name", ShortName = "Division Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Required]
        public string DivisionName { get; set; } = null!;

        public List<LprDivision01> DivisionRef01 { get; set; } = null!;
        public List<LprDivision02> DivisionRef02 { get; set; } = null!;
    }
}

#endif