

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhBkEntity.Auth
{
    public class aspnetmodel
    {
        [Required]
        [Display(Description = "Model Id", Name = "Model Id", Prompt = "Enter Model Id", ShortName = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModelPk { get; set; }

        [Required]
        [Display(Description = "Model Name", Name = "Model Name", Prompt = "Enter ModelName", ShortName = "Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Invalid")]
        public string ModelName { get; set; } = null!;

        [Display(Description = "Model Description", Name = "Model Description", Prompt = "Enter ModelDescription", ShortName = "Description")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Invalid")]
        public string ModelDescription { get; set; } = null!;

        public virtual ICollection<aspnetrolemask> RoleMasks { get; set; }= null!;

    }
}

