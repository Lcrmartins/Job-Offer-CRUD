using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobWebApp.Models
{
    public class JobOffer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must fill the Title field.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must fill the City field.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 2)]
        public string Local { get; set; }

        [Required(ErrorMessage = "You must fill the Description field.")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must fill the Responsibility field.")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 3)]
        public string Responsibility { get; set; }

        [Required(ErrorMessage = "You must fill the Requirement field.")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and a maximum of {1} characters.", MinimumLength = 3)]
        public string Requirement { get; set; }

        [Required(ErrorMessage = "You must fill the Post Date field.")]
        [DataType(DataType.Date, ErrorMessage ="Date in wrong format")]
        [Display(Name = "Post Date")]
        public DateTime? PostDate { get; set; }

        [Required(ErrorMessage = "You must fill the Wage field.")]
        [Range(1, 1000000, ErrorMessage = "The Wage must be from $1.00 to $1M.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Wage { get; set; }

        [Required(ErrorMessage = "You must fill the contribution field (in %).")]
        [Range(0.1, 10)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Contribution { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ModWage { get; set; }

        [DisplayName("Job Position")]
        public int IdType { get; set; }
        [ForeignKey("IdType")]

        public virtual Position Position { get; set; }
    }
}
