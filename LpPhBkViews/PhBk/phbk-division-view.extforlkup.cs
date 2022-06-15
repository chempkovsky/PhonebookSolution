#nullable disable
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


using PhBkViews.PhBk;




namespace LpPhBkViews.PhBk {

    public class PhbkDivisionViewExtForLkUp: IPhbkDivisionViewExtForLkUp  {
        [JsonPropertyName("divisionId")]
        [Required]
        [Display(Description="Row id",Name="Id of the Division",Prompt="Enter Division Id",ShortName="Division Id")]
        public System.Int32  DivisionId { get; set; }

        [JsonPropertyName("divisionName")]
        [Required]
        [Display(Description="Name of the Enterprise Division",Name="Name of the Division",Prompt="Enter Division Name",ShortName="Division Name")]
        [StringLength(20,MinimumLength=3,ErrorMessage="Invalid")]
        public System.String  DivisionName { get; set; } = null!;

        [JsonPropertyName("entrprsIdRef")]
        [Required]
        [Display(Description="Row id",Name="Id of the Enterprise",Prompt="Enter Enterprise  Id",ShortName="Enterprise Id")]
        public System.Int32  EntrprsIdRef { get; set; }

    }

    public static class PhbkDivisionViewCloneForLkUp {
        public static IPhbkDivisionViewExtForLkUp  DoClone(PhbkDivisionView src) {
            PhbkDivisionViewExtForLkUp dest = new PhbkDivisionViewExtForLkUp();
            if(src != null) {
                dest.DivisionId = src.DivisionId;
                dest.DivisionName = src.DivisionName;
                dest.EntrprsIdRef = src.EntrprsIdRef;
            }
            return dest;
        }
    }
}

