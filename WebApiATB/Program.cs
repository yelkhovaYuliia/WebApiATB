using Domain;
using Microsoft.EntityFrameworkCore;
using WebApiATB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opt=>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("MyAtbConnection")));

builder.Services.AddControllers();

//додали свагера
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

await app.SeedData();

app.Run();
