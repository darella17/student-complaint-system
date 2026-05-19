using Microsoft.EntityFrameworkCore;
using StudentComplaintSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddSession();

// DATABASE CONFIGURATION
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

if (!string.IsNullOrEmpty(databaseUrl))
{
    // Render PostgreSQL database
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');

    var connectionString =
        $"Host={uri.Host};" +
        $"Port={uri.Port};" +
        $"Database={uri.AbsolutePath.TrimStart('/')};" +
        $"Username={userInfo[0]};" +
        $"Password={userInfo[1]};" +
        $"SSL Mode=Require;Trust Server Certificate=true";

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));
}
else
{
    // Local SQLite for development
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=complaints.db"));
}

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

// Configure pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// Create database automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();