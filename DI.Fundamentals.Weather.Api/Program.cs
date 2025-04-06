using Weather.Api.Filter;
using Weather.Api.Service;
using Weather.Api.Weather;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices Starts -> Builder creation 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddTransient<IWeatherService, OpenWeatherService>();
builder.Services.AddScoped<LifetimeIndicatorFilter>();
builder.Services.AddScoped<IdGenerator>();
// ConfigureService Ends

var app = builder.Build();

// Configure Starts -> Application creation 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//Configure End

app.Run();
