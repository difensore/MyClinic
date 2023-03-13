using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyClinic.DAL.Models;
using MyClinic.Interfaces;
using MyClinic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyClinicContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<User, IdentityRole>(opts => {
    opts.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<MyClinicContext>();
builder.Services.AddTransient<IIdentityProvider, IdentityProvider>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
