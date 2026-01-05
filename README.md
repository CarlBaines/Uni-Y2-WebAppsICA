# Apex Events Management System

## 📌 Overview
This project was developed as part of my **Web Apps & Services (CIS2058-N)** in-course assessment at university.

It is an **ASP.NET Core 8.0 Razor Pages web application** designed as an event management system for a hypothetical events company called **Apex**. The system allows staff to manage:

- Events
- Guests
- Staffing
- Catering
- Venue reservations

The solution follows a **service-oriented architecture**, with separate web services handling catering and venues.

---

## 🧩 Solution Structure
The solution consists of three main components:

- **Apex.Events**  
  Razor Pages web application (main user interface)

- **Apex.Catering**  
  Web API for managing food items, menus, and food bookings

- **Apex.Venues**  
  Web service for venue availability and event types  
  *(Provided as part of the assessment – not modified)*

---

## 🛠️ Tech Stack
- ASP.NET Core 8.0
- Razor Pages
- Entity Framework Core
- SQLite
- RESTful Web APIs

---

## ⚠️ Key Problems, Challenges & Resolutions
The following issues were encountered during development and demonstrate problem-solving, debugging, and design decisions across Razor Pages, EF Core, and API integration.

### 🔹 Apex.Catering – Deletion of Food Items
**Problem**  
DELETE requests failed due to foreign key constraints (`MenuFoodItem` depended on `FoodItem`).

**Resolution**  
Configured the relationship in `CateringDbContext` to use `DeleteBehavior.Cascade` and applied the change via a migration.

---

### 🔹 Missing EF Core Attributes in Apex.Events
**Problem**  
Domain models lacked required EF Core attributes, causing scaffolding and validation issues.

**Resolution**  
Added `[Key]`, `[Required]`, `[MaxLength]`, and navigation properties based on the ERD.

---

### 🔹 Staff Entity Missing Primary Key
**Problem**  
EF Core error:  
> The entity type 'Staff' requires a primary key to be defined.

**Resolution**  
Added a `StaffId` primary key and regenerated migrations.

---

### 🔹 Scaffolded CRUD Pages Failing
**Problem**  
Using `event` as a variable name caused compile-time errors (reserved C# keyword).

**Resolution**  
Renamed variables to `evt` / `eventItem`.

---

### 🔹 Namespace Conflict with Staff Pages
**Problem**  
Folder named `Staffs` conflicted with namespace resolution.

**Resolution**  
Renamed the folder to `Staff`.

---

### 🔹 Linking Apex.Events to Apex.Catering
**Problem**  
Required communication between the Events app and Catering API.

**Resolution**  
Implemented an `HttpClient` service with async methods for creating, editing, cancelling, and retrieving food bookings.

---

### 🔹 Editing Event Name Not Working
**Problem**  
`ModelState` was invalid due to a missing `EventType` input on the Edit page.

**Resolution**  
Added the missing form field and pre-populated it.

---

### 🔹 Retrieving Event Types from Apex.Venues
**Problem**  
Event types needed to be retrieved dynamically from the Venues service.

**Resolution**  
Added an API call and populated a `SelectList` in the PageModel.

---

### 🔹 Event Details Page Showing Limited Data
**Problem**  
Scaffolded page only displayed the event name.

**Resolution**  
Added `DisplayNameFor` and `DisplayFor` helpers for event type and date.

---

### 🔹 Seeding Data for Apex.Catering
**Problem**  
The Catering API required initial data for menus and food items.

**Resolution**  
Created a `DbTestDataInitialiser` to seed data on startup.

---

### 🔹 Booking Guests onto Events
**Problem**  
Guest bookings required correct foreign key handling and duplicate prevention.

**Resolution**  
Created a dedicated booking page and added duplicate checks.

---

### 🔹 Food Bookings Not Displaying
**Problem**  
Food bookings were not visible in the Events UI.

**Resolution**  
Added a section on the Event Details page to retrieve and display bookings via the Catering API.

---

### 🔹 Separate Food Booking Page
**Problem**  
Food booking was too tightly coupled to the Event Edit page.

**Resolution**  
Created a dedicated food booking page with menu selection and confirmation.

---

### 🔹 Preventing Multiple Food Bookings
**Problem**  
Users could attempt multiple bookings for the same event.

**Resolution**  
Added a PageModel check to hide the booking link if a booking already exists.

---

## 📁 File Structure
