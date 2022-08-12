// create web-app
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISpeedingViolationCalculator>(
    new DefaultSpeedingViolationCalculator("A12", 10, 100, 5));

// Register the IVehicleStateRepository implementation
// Add dapr client
// Register dapr actors

var app = builder.Build();

// configure web-app
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseCloudEvents();

// configure routing
app.MapControllers();
app.MapActorsHandlers();

// let's go!
app.Run("http://localhost:6000");
