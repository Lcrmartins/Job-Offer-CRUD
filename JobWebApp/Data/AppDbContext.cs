using JobWebApp.Models;
using JobWebApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JobWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<JobOffer> Job { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<JobOfferVM> jobOfferVM { get; set; }

    }
}
