# Apex Events Management System

## Overview
This project is part of my university in-course assessment for my Web Apps & Services module (CIS2058-N). It is an ASP.NET Core 8.0 Razor Pages web application that is designed to function as an event management system for a hypothetical events company called Apex. The system allows staff to manage events, guests, staffing, catering and venue reservations. <br>
The solution consists of three main components: <br>
<ul>
  <li><b>Apex.Events</b> - Razor Pages Web Application</li>
  <li><b>Apex.Catering</b> - Web API for managing food items, menus and food bookings.</li>
  <li><b>Apex.Venues</b> - Web Service for venue availability and reservations</li>
</ul>

## Tech Stack
<ul>
  <li>ASP.NET Core 8.0</li>
  <li>Razor Pages</li>
  <li>Entity Framework Core</li>
  <li>SQLite</li>
  <li>Web API</li>
</ul>

### Key Problems, Challenges & How They Were Resolved
Below is a summary of the main technical issues I encountered during development, along with how I resolved each. These reflect debugging, build decisions and EF Core/Razor Pages challenges.
#### (Apex.Catering) - Deletion of Food Items
**Problem:** DELETE requests failed due to foreign key constraints (MenuFoodItem depended on FoodItem). <br>
**Fix:**  Updated the relationship in CateringDbContext to use DeleteBehavior.Cascade and created a migration to apply the new behaviour.
#### Creating Class Attributes for Apex.Events
**Problem:** Domain classes lacked required EF Core attributes, causing scaffolding and validation issues. <br>
**Fix:** Added [Key], [Required], [MaxLength], and navigation properties based on the ERD so EF Core could generate correct migrations and Razor Pages could validate input.
#### Primary Key Missing for Staff Entity
**Problem:** EF Core error: “The entity type 'Staff' requires a primary key to be defined. <br>
**Fix:** Added a primary key property (StaffId) and regenerated migrations.
#### Apex.Events Scaffolded CRUD Pages Erroring
**Problem:** Using event as a variable name caused compile‑time errors (reserved C# keyword). <br>
**Fix:** Renamed the variable to evt / eventItem.
#### Compiler Resolving IList<Staff> as Namespace
**Problem:** The folder containing Staff pages was named Staffs, conflicting with namespace resolution. <br>
**Fix:** Renamed the folder to Staff.
#### Linking Apex.Events to Apex.Catering
**Problem:** Needed to call the Catering API from the Events app. <br>
**Fix:** Created an HttpClient service and added typed methods for creating, editing, cancelling, and retrieving food bookings. Integrated these into Razor Pages using async handlers.
#### Editing EventName Not Working
**Problem:** ModelState invalid due to missing EventType input on the Edit page. <br>
**Fix:** Added the missing field to the form and prepopulated it
#### Retrieving Event Types from Apex.Venues
**Problem:** Needed a dropdown list of event types from the Venues service. <br>
**Fix:** Added an API call to Apex.Venues and populated a SelectList in the PageModel.
#### Event Details Page Only Showing Event Name
**Problem:**: Scaffolded page only displayed the title <br>
**Fix:**: Added DisplayNameFor and DisplayFor helpers for EventType and EventDate.
#### DbTestDataInitialiser Needed for Apex.Catering
**Problem:**: Catering API required seed data for menus, food items, and relationships. <br>
**Fix:**: Created a DbTestDataInitialiser to seed sample data on startup.
#### Booking a Guest onto an Event
**Problem**: GuestBookings required correct FK handling and duplicate prevention. <br>
**Fix**: Created a dedicated booking page and added a check to prevent duplicate bookings.
#### Food Booking Not Displaying in Razor Pages
**Problem:**: Catering API returned a FoodBookingId, but the Events UI didn’t show food bookings. <br>
**Fix:** Added a section on the Event Details page that retrieves and displays the booking via the Catering API.
#### Separate “Create Food Booking” Page Needed
**Problem:** Food booking was too tightly coupled to Event Edit. <br>
**Fix:** Created a dedicated page allowing menu selection and booking confirmation.
#### Hide Food Booking Link When Food Already Booked
**Problem:** Users could attempt multiple bookings. <br>
**Fix:** Added a check in the PageModel to query the Catering API and hide the link if a booking exists.

### File Structure
/Apex.Events <br>
/Apex.Catering <br>
/Apex.Venues (provided – not modified) <br>
README.md

### How to Run the Project
- Open the solution in Visual Studio 2022.
- Ensure all three projects build successfully.
- Run the solution with multiple startup projects:
- Apex.Events
- Apex.Catering
- Apex.Venues
- The Events app will open in the browser and communicate with the two services.
