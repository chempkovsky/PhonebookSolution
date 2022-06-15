#nullable disable
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


using PhBkViews.PhBk;




namespace LpPhBkViews.PhBk {

    public class PhbkPhoneViewExtForLkUp: IPhbkPhoneViewExtForLkUp  {
        [JsonPropertyName("phoneId")]
        [Required]
        [Display(Description="Row id",Name="Phone Id",Prompt="Enter Phone Id",ShortName="Phone Id")]
        public System.Int32  PhoneId { get; set; }

        [JsonPropertyName("phone")]
        [Required]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        [Display(Description="Name of the Phone Type",Name="Phone",Prompt="Enter Phone",ShortName="Phone")]
        public System.String  Phone { get; set; } = null!;

        [JsonPropertyName("employeeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Employee",Prompt="Enter Employee  Id",ShortName="Employee Id")]
        public System.Int32  EmployeeIdRef { get; set; }

        [JsonPropertyName("phoneTypeIdRef")]
        [Required]
        [Display(Description="Row id",Name="Phone Type Id",Prompt="Enter Phone Type Id",ShortName="Phone Type Id")]
        public System.Int32  PhoneTypeIdRef { get; set; }

    }

    public static class PhbkPhoneViewCloneForLkUp {
        public static IPhbkPhoneViewExtForLkUp  DoClone(PhbkPhoneView src) {
            PhbkPhoneViewExtForLkUp dest = new PhbkPhoneViewExtForLkUp();
            if(src != null) {
                dest.PhoneId = src.PhoneId;
                dest.Phone = src.Phone;
                dest.EmployeeIdRef = src.EmployeeIdRef;
                dest.PhoneTypeIdRef = src.PhoneTypeIdRef;
            }
            return dest;
        }
    }
}

