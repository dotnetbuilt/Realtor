using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contexts;
using Realtor.WebApi.Extensions;
using Serilog;
using ExceptionHandlerMiddleware = Realtor.WebApi.Middlewares.ExceptionHandlerMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//DbContext
builder.Services.AddDbContext<RealtorDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//JWT
builder.Services.AddJwt(builder.Configuration);

//Custom Services
builder.Services.AddCustomServices();

// //Swagger Setup
// builder.Services.ConfigureSwagger();

//Logger (Serilog)
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();