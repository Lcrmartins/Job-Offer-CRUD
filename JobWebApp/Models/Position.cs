using System.ComponentModel.DataAnnotations;

namespace JobWebApp.Models
{
    public class Position
    {
        [Key]
        public int IdType { get; set; }

        [Required(ErrorMessage = "You must fill the Position Type field.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 3)]
        [Display(Name = "Position Type")]
        public string Type { get; set; }
    }
}
