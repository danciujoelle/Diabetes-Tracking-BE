using DiabetesTrackingServer.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DiabetesTrackingServer.DataAccess
{
    public class DiabetesTrackingContext : DbContext
    {
        public DiabetesTrackingContext(DbContextOptions<DiabetesTrackingContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<DiabetesPrediction> Predictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;database=DiabetesTracking;Integrated Security=True;");
        }

    }
}
