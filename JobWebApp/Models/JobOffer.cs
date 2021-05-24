using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        [DataType(DataType.Date)]
        [Display(Name = "Post Date")]
        public DateTime PostDate { get; set; }

        [Required(ErrorMessage = "You must fill the Wage field.")]
        public decimal Wage { get; set; }

    }
}
