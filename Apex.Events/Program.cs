using Apex.Events.Data;
using Apex.Events.Services;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register database context with the framework
builder.Services.AddDbContext<EventsDbContext>();
// Register the database initialiser
builder.Services.AddScoped<DbTestDataInitialiser>();

// Register application services
builder.Services.AddHttpClient<EventTypesService>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7088/");
});

builder.Services.AddHttpClient<VenuesService>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7088/");
});

builder.Services.AddHttpClient<FoodBookingsService>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7012/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else
{
    // Seeds the database only in the development environment.
    AddSeedData(app);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Minimal API for Catering validation: GET api/Events/{id}
app.MapGet("api/Events/{id:int}", async(int id, EventsDbContext db) =>
{
    var evt = await db.Events.FindAsync(id);
    if(evt == null)
    {
        return Results.NotFound(new { message = $"Event {id} not found" });
    }
    return Results.Ok(evt);
});

app.Run();

void AddSeedData(IHost host)
{
    using var scope = host.Services.CreateScope();
    var dbInitialiser = scope.ServiceProvider.GetRequiredService<DbTestDataInitialiser>();
    dbInitialiser.Initialise();
}