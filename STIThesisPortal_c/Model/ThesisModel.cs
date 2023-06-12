using System.ComponentModel.DataAnnotations;

namespace STIThesisPortal_c.Model
{
    public class ThesisModel
    {
        [Key]

        [Required(ErrorMessage = "Please enter Accession code")]
        [Display(Name = "Accession")]
        public String accession { get; set; }

        [Required(ErrorMessage = "Please enter Call number")]
        [Display(Name = "Call No.")]
        public String callNo { get; set; }

        [Display(Name = "Author/s")]
        public String? author { get; set; }

        [Required(ErrorMessage = "Please enter Thesis Title")]
        [Display(Name = "Title")]
        public String title { get; set; }

        [Required(ErrorMessage = "Please enter Year")]
        [Display(Name = "Year")]
        public int year { get; set; }
    }
}
