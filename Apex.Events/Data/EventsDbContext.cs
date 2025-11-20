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
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Models the many-to-one relationshop between GuestBookings and Events.
            modelBuilder.Entity<GuestBooking>()
                .HasOne(gb => gb.Event)
                .WithMany(gb => gb.GuestBookings)
                .HasForeignKey(gb => gb.EventId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Models the many-to-one relationship between Staffing and Staff.
            modelBuilder.Entity<Staffing>()
                .HasOne(st => st.Staff)
                .WithMany(st => st.Staffings)
                .HasForeignKey(st => st.EventStaffId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Models the many-to-one relationship between Staffing and Events.
            modelBuilder.Entity<Staffing>()
                .HasOne(st => st.Event)
                .WithMany(st => st.Staffings)
                .HasForeignKey(st => st.EventId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Insert seed data for guest bookings
            modelBuilder.Entity<GuestBooking>().HasData(
                new GuestBooking { GuestBookingId = 1, GuestId = 1, EventId = 1 },
                new GuestBooking { GuestBookingId = 2, GuestId = 2, EventId = 1 },
                new GuestBooking { GuestBookingId = 3, GuestId = 3, EventId = 2 }
            );

            // Insert seed data for guests
            modelBuilder.Entity<Guest>().HasData(
                new Guest { GuestId = 1, FirstName = "Alice", LastName = "Johnson" },
                new Guest { GuestId = 2, FirstName = "Bob", LastName = "Smith" },
                new Guest { GuestId = 3, FirstName = "Charlie", LastName = "Brown" }
            );

            // Insert seed data for events
            modelBuilder.Entity<Event>().HasData(
                new Event { EventId = 1, EventName = "Annual Conference" },
                new Event { EventId = 2, EventName = "Networking Gala" }
            );

            // Insert seed data for staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff { EventStaffId = 1, FirstName = "David", LastName = "Wilson" },
                new Staff { EventStaffId = 2, FirstName = "Eva", LastName = "Davis" }
            );

            // Insert seed data for staffings
            modelBuilder.Entity<Staffing>().HasData(
                new Staffing { StaffingId = 1, EventStaffId = 1, EventId = 1 },
                new Staffing { StaffingId = 2, EventStaffId = 2, EventId = 2 }
            );
        }
    }
}
