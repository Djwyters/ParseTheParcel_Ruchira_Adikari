using Trademe.Services.Options;
using Trademe.Api.Mappings;

var builder = WebApplication.CreateBuilder(args);

Trademe.Core.Dependencies.ConfigurationServices(builder.Services, builder.Configuration);
Trademe.Services.Dependencies.ConfigurationServices(builder.Services, builder.Configuration);

builder.Services.Configure<List<PackageDetails>>(
    builder.Configuration.GetSection("PackageDetails"));

builder.Services.Configure<WeightDetails>(
    builder.Configuration.GetSection("WeightDetails"));

builder.Services.AddAutoMapper(typeof(PackageMapping));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
