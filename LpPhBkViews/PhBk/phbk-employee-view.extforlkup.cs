// #nullable disable
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


using PhBkViews.PhBk;




namespace LpPhBkViews.PhBk {

    public class PhbkEmployeeViewExtForLkUp: IPhbkEmployeeViewExtForLkUp  {
        [JsonPropertyName("employeeId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeId { get; set; }

        [JsonPropertyName("empLastName")]
        [Required]
        [Display(Description="Last Name of the Employee",Name="Employee Last Name",Prompt="Enter Employee Last Name",ShortName="Last Name")]
        [StringLength(40,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpLastName { get; set; } = null!;

        [JsonPropertyName("empFirstName")]
        [Required]
        [Display(Description="First Name of the Employee",Name="Employee First Name",Prompt="Enter Employee First Name",ShortName="First Name")]
        [StringLength(25,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  EmpFirstName { get; set; } = null!;

        [JsonPropertyName("empSecondName")]
        [Display(Description="Row id",Name="Employee Second Name",Prompt="Enter Employee Second Name",ShortName="Second Name")]
        [StringLength(25,ErrorMessage="Invalid")]
        public System.String ?  EmpSecondName { get; set; }

        [JsonPropertyName("divisionIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionIdRef { get; set; }

    }

    public static class PhbkEmployeeViewCloneForLkUp {
        public static IPhbkEmployeeViewExtForLkUp  DoClone(PhbkEmployeeView src) {
            PhbkEmployeeViewExtForLkUp dest = new PhbkEmployeeViewExtForLkUp();
            if(src != null) {
                dest.EmployeeId = src.EmployeeId;
                dest.EmpLastName = src.EmpLastName;
                dest.EmpFirstName = src.EmpFirstName;
                dest.EmpSecondName = src.EmpSecondName;
                dest.DivisionIdRef = src.DivisionIdRef;
            }
            return dest;
        }
    }
}

