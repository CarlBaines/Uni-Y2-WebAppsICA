using Microsoft.EntityFrameworkCore;

namespace Apex.Events.Data
{
    public class EventsDbContext : DbContext
    {
        // Db Set Attributes
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestBooking> GuestBookings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Staffing> Staffings { get; set; }
        private string DbPath { get; set; } = string.Empty;

        // Constructor
        public EventsDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "C# Databases/ICA Databases", "events.db");

            var directory = Path.GetDirectoryName(DbPath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        // Set the database to use SQLite and the database file path
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source = {DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Models the many-to-one relationship between GuestBookings and Guests.
            modelBuilder.Entity<GuestBooking>()
                .HasOne(gb => gb.Guest)
                .WithMany(gb => gb.GuestBookings)
                .HasForeignKey(gb => gb.GuestId)
                .IsRequired();
                //.OnDelete(DeleteBehavior.Restrict)
            
                
        }
    }
}
