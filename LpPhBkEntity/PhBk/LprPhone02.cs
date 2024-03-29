﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LpPhBkEntity.PhBk
{
    public class LprPhone02
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row id", Name = "Phone Id", Prompt = "Enter Phone Id", ShortName = "Phone Id")]
        [Required]
        public int PhoneId { get; set; }
        //public PhbkPhone Phone { get; set; } = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Description = "Row id", Name = "Id of the Row", Prompt = "Enter Row Id", ShortName = "Row Id")]
        [Required]
        public int LpdPhoneIdRef { get; set; }

        public LpdPhone PhoneDict { get; set; } = null!;

        [Display(Description = "Row id", Name = "Id of the Employee", Prompt = "Enter Employee  Id", ShortName = "Employee Id")]
        [Required]
        public int EmployeeIdRef { get; set; }

        //public PhbkEmployee Employee { get; set; } = null!;

    }
}
