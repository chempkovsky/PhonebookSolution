

using System.ComponentModel.DataAnnotations;


namespace PhBkEntity.Auth
{
    public class aspnetrolemask
    {
        
        [Required]
        [Display(Description = "Role Name", Name = "Role Name", Prompt = "Enter RoleName", ShortName = "Role Name")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "Invalid")]
        public string RoleName { get; set; } = null!;

        [Display(Description = "Role Description", Name = "Role Description", Prompt = "Enter Role Description", ShortName = "Description")]
        [StringLength(70, MinimumLength = 0, ErrorMessage = "Invalid")]
        public string RoleDescription { get; set; } = null!;


        [Display(Description = "Permission to Sel", Name = "Permission to Sel", Prompt = "Enter permission to Sel", ShortName = "Sel")]
        [Required]
        public bool Mask1 { get; set; }

        [Display(Description = "Permission to Del", Name = "Permission to Del", Prompt = "Enter permission to Del", ShortName = "Del")]
        [Required]
        public bool Mask2 { get; set; }

        [Display(Description = "Permission to Upd", Name = "Permission to Upd", Prompt = "Enter permission to Upd", ShortName = "Upd")]
        [Required]
        public bool Mask3 { get; set; }

        [Display(Description = "Permission to Add", Name = "Permission to Add", Prompt = "Enter permission to Add", ShortName = "Add")]
        [Required]
        public bool Mask4 { get; set; }

        [Display(Description = "Full scan permission", Name = "Full scan permission", Prompt = "Enter Full scan permission", ShortName = "FullScan")]
        [Required]
        public bool Mask5 { get; set; }

        [Required]
        [Display(Description = "Model Id", Name = "Model Id", Prompt = "Enter Model Id", ShortName = "Id")]
        public int ModelPkRef { get; set; }

        public virtual aspnetmodel AspNetModel { get; set; } = null!;


    }
}


