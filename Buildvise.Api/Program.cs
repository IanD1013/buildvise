using Buildvise.Application;
using Buildvise.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Configuration.AddJsonFile("appsettings.Secrets.json", optional: true, reloadOnChange: true);
    
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddProblemDetails();

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    
    app.Run();
}