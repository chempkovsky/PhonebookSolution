using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LpPhBkEntity.PhBk
{
    public class LprEmployee02
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Emp Row id", Name = "Id of the Employee", Prompt = "Enter Employee Id", ShortName = "Employee Id")]
        [Required]
        public int EmployeeId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Lst name ref id", Name = "Lst name  ref Id", Prompt = "Enter Lst name ref Id", ShortName = "Lst name ref Id")]
        [Required]
        public int EmpLastNameIdRef { get; set; }

        public LpdEmpLastName EmpLastNameDict { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Frst name ref id", Name = "Frst name  ref Id", Prompt = "Enter Frst name ref Id", ShortName = "Frst name ref Id")]
        [Required]
        public int EmpFirstNameIdRef { get; set; }

        public LpdEmpFirstName EmpFirstNameDict { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Sec name ref id", Name = "Sec name  ref Id", Prompt = "Enter Sec name ref Id", ShortName = "Sec name ref Id")]
        [Required]
        public int EmpSecondNameIdRef { get; set; }

        public LpdEmpSecondName EmpSecondNameDict { get; set; } = null!;

        [Display(Description = "Division Row id", Name = "Id of the Division", Prompt = "Enter Division Id", ShortName = "Division Id")]
        [Required]
        public int DivisionIdRef { get; set; }

    }
}
