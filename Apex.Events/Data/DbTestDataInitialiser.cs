using System;
using Microsoft.EntityFrameworkCore;

namespace Apex.Events.Data
{
    public class DbTestDataInitialiser
    {
        private readonly EventsDbContext _context;
        // Constructor
        public DbTestDataInitialiser(EventsDbContext context)
        {
            _context = context;
        }

        public void Initialise()
        {
            // This will apply any pending migrations for the context to the database.
            _context.Database.Migrate();
            // Check if there are any events in the database.
            if (_context.Events.Any() || _context.Guests.Any() || _context.Staff.Any() || _context.Staffings.Any() || _context.GuestBookings.Any())
            {
                return; // Database has already been seeded.
            }

            // Seed Events
            var events = new[]
            {
                new Event { EventId = 1, EventName = "Annual Conference", EventDate = new DateOnly(2025, 5, 12), EventType = "Conference" },
                new Event { EventId = 2, EventName = "Networking Gala", EventDate = new DateOnly(2025, 6, 20), EventType = "Gala" },
                new Event { EventId = 3, EventName = "Tech Expo", EventDate = new DateOnly(2025, 9, 3), EventType = "Expo" }
            };
            _context.Events.AddRange(events);

            // Seed Guests
            var guests = new[]
            {
                new Guest { GuestId = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com" },
                new Guest { GuestId = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@example.com" },
                new Guest { GuestId = 3, FirstName = "Charlie", LastName = "Brown", Email = "charlie@example.com" },
                new Guest { GuestId = 4, FirstName = "Dana", LastName = "White", Email = "dana@example.com" }
            };
            _context.Guests.AddRange(guests);

            // Seed Staff
            var staff = new[]
            {
                new Staff { EventStaffId = 1, FirstName = "David", LastName = "Wilson", Role = "Coordinator" },
                new Staff { EventStaffId = 2, FirstName = "Eva", LastName = "Davis", Role = "Assistant" },
                new Staff { EventStaffId = 3, FirstName = "Frank", LastName = "Edwards", Role = "Technician" }
            };
            _context.Staff.AddRange(staff);

            // Seed Staffings
            var staffings = new[]
            {
                new Staffing { StaffingId = 1, StaffingName = "Conference Coordination", EventStaffId = 1, EventId = 1 },
                new Staffing { StaffingId = 2, StaffingName = "Gala Assistance", EventStaffId = 2, EventId = 2 },
                new Staffing { StaffingId = 3, StaffingName = "Expo Technical Support", EventStaffId = 3, EventId = 3 }
            };
            _context.Staffings.AddRange(staffings);

            // Seed GuestBookings
            var bookings = new[]
            {
                new GuestBooking { GuestBookingId = 1, GuestId = 1, EventId = 1 },
                new GuestBooking { GuestBookingId = 2, GuestId = 2, EventId = 1 },
                new GuestBooking { GuestBookingId = 3, GuestId = 3, EventId = 2 },
                new GuestBooking { GuestBookingId = 4, GuestId = 4, EventId = 3 }
            };
            _context.GuestBookings.AddRange(bookings);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new InvalidOperationException($"Database seeding failed due to a database update: {e.Message}");
            }
        }
    }
}
