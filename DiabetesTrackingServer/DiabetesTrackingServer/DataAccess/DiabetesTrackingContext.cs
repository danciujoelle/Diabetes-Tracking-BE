using DiabetesTrackingServer.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DiabetesTrackingServer.DataAccess
{
    public class DiabetesTrackingContext : DbContext
    {
        public DiabetesTrackingContext(DbContextOptions<DiabetesTrackingContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<DiabetesPrediction> Predictions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<GlucoseLog> GlucoseLogs { get; set; }
        public DbSet<InsulinLog> InsulinLogs { get; set; }
        public DbSet<SportLog> SportLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;database=DiabetesTracking;Integrated Security=True;");
        }

    }
}
