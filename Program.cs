using E_commers_project;
using E_commers_project.IRepo;
using E_commers_project.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
      option.UseSqlServer(builder.Configuration.GetConnectionString("connect")));

builder.Services.AddScoped<Iuserrepo, userrepo>();
builder.Services.AddScoped<Isellerrepo, SellerRepo>();
builder.Services.AddScoped<Iporductrepo, productrepo>();


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
