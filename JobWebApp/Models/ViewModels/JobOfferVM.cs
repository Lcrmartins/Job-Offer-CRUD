using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobWebApp.Models.ViewModels
{
    [Keyless]
    public class JobOfferVM
    {
        
        public JobOffer JobOffer { get; set; }
        
        public IEnumerable<SelectListItem> PositionDropDown { get; set; }
    }
}
