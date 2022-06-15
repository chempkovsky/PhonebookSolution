#if (!NOTMODELING)

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhBkEntity.PhBk
{
    public class LprDivision01
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row id", Name = "Id of the Division", Prompt = "Enter Division Id", ShortName = "Division Id")]
        [Required]
        public int DivisionId { get; set; }

        public PhbkDivision Division { get; set; } = null!;


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row id", Name = "Id of the Division", Prompt = "Enter Division Id", ShortName = "Division Id")]
        [Required]
        public int DivisionNameIdRef { get; set; }

        public LpdDivision DivisionNameDict { get; set; } = null!;
    }
}

#endif