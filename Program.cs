using TaxabilityWebAPI.Services;
using TaxabilityWebAPI.Services.Impl;
using SnapObjects.Data;
using SnapObjects.Data.SqlServer;
using TaxabilityWebAPI;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaxabilityService, TaxabilityService>();

// Add services to the container.
builder.Services.AddDataContext<MSSDataContext>(m => m.UseSqlServer(builder.Configuration, "il095-dwwinbiddb-001.database.windows.net.sf_poc"));

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
