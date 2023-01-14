using AdessoRideShareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdessoRideShareAPI.Data
{
    public class AdessoRideShareDBContext : DbContext
    {

        public AdessoRideShareDBContext(DbContextOptions<AdessoRideShareDBContext> options) : base(options)
        {

        }
        public DbSet<TravelPlan> TravelPlans { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
    }
}
