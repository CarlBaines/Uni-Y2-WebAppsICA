using Apex.Catering.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register database context with the framework
builder.Services.AddDbContext<CateringDbContext>();
builder.Services.AddScoped<DbTestDataInitialiser>();

// Register named HttpClient for accessing Events API
builder.Services.AddHttpClient("Events", httpClient =>
{
    var baseUrl = "https://localhost:7011/";
    httpClient.BaseAddress = new Uri(baseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    AddSeedData(app);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Helper method to add seed data to the database using the DbTestDataInitialiser service
void AddSeedData(IHost host)
{
    using var scope = host.Services.CreateScope();
    var dbInitialiser = scope.ServiceProvider.GetRequiredService<DbTestDataInitialiser>();
    dbInitialiser.Initialise();
}   