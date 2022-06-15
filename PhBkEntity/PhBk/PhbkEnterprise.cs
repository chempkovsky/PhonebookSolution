using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class PhbkEnterprise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row id", Name = "Id of the Enterprise", Prompt = "Enter Enterprise  Id", ShortName = "Enterprise Id")]
        [Required]
        public int EntrprsId { get; set; }

        [Display(Description = "Name of the Enterprise", Name = "Name of the Enterprise", Prompt = "Enter Enterprise Name", ShortName = "Enterprise Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid")]
        [Required]
        public string EntrprsName { get; set; } = null!;

        [Display(Description = "Description of the Enterprise", Name = "Description of the Enterprise", Prompt = "Description Enterprise Name", ShortName = "Enterprise Description")]
        [StringLength(250, ErrorMessage = "Invalid")]
        public string? EntrprsDesc { get; set; }

        public List<PhbkDivision> Divisions { get; set; } = null!;

#if (!NOTMODELING)
        public List<LprDivision02> DivisionRefs02 { get; set; } = null!;
#endif

    }
}
