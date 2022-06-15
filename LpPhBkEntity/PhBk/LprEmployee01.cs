using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LpPhBkEntity.PhBk
{
    public class LprEmployee01
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row id", Name = "Id of the Employee", Prompt = "Enter Employee  Id", ShortName = "Employee Id")]
        [Required]
        public int EmployeeId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row ref id", Name = "ref Id of the Row", Prompt = "Enter Row ref Id", ShortName = "Row ref Id")]
        [Required]
        public int EmpLastNameIdRef { get; set; }

        public LpdEmpLastName EmpLastNameDict { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row ref id", Name = "ref Id of the Row", Prompt = "Enter Row ref Id", ShortName = "Row ref Id")]
        [Required]
        public int EmpFirstNameIdRef { get; set; }

        public LpdEmpFirstName EmpFirstNameDict { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "S name ref id", Name = "Id of the Row", Prompt = "Enter Row Id", ShortName = "Row Id")]
        [Required]
        public int EmpSecondNameIdRef { get; set; }

        public LpdEmpSecondName EmpSecondNameDict { get; set; } = null!;
    }
}
