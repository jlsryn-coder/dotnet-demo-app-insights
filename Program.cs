using OpenTelemetry.Resources;

var builder = WebApplication.CreateBuilder(args);

// The following line enables Application Insights telemetry collection.
builder.Services.AddApplicationInsightsTelemetry();

// This code adds other services for your application.
builder.Services.AddControllersWithViews();
// In older .net core it will be services.AddMvc();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add OpenTelemetry service name
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource =>
        resource.AddService("dotnet-demo-app"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
