using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.HttpLogging;
using System.Globalization;
using SignalRChatApp;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Enable logger
// Log.Logger = new LoggerConfiguration()
//     .WriteTo.File("Logs/app_.log", rollingInterval: RollingInterval.Day)
//     .CreateLogger();
// builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.File("Logs/missing-localization.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();


// Add services to the container.
builder.Services.AddRazorPages();

// http logging
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("User-Agent");
    logging.MediaTypeOptions.AddText("application/json");
    //logging.RequestBodyLogLimit = 4096;
    //logging.ResponseBodyLogLimit = 4096;
});

// Add sqlite database support
builder.Services.AddDbContext<ChatDbContext>(options =>
    options.UseSqlite("Data Source=chat.db"));

// Enable SignalR for real-time communication
builder.Services.AddSignalR();

// Add localization for en and zh
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddRazorPages()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

//FIXME: Plan for using navigationState 
//builder.Services.AddSingleton<INavigationState, NavigationState>();

var app = builder.Build();

// i18n localization support
var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("fr"), new CultureInfo("zh") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpLogging();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapHub<ChatHub>("/chatHub");




using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ChatDbContext>();
    db.Database.Migrate();
}



app.Run();
