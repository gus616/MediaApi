using FluentValidation;
using MediaApi.DTOs;
using MediaApi.Models;
using MediaApi.Repository;
using MediaApi.Services;
using MediaApi.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAlbumService, AlbumService>();

builder.Services.AddScoped<IRepository<Album>, AlbumRepository>();

builder.Services.AddScoped<IRepository<User>, UserRepository>();

builder.Services.AddScoped<IValidator<UserInsertDto>, UserInsertValidator>();
builder.Services.AddScoped<IValidator<AlbumInsertDto>, AlbumInsertValidator>();

builder.Services.AddDbContext<MediaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MediaContext>()
    .AddDefaultTokenProviders();


builder.Services.AddControllers();

//Add JWT Authentication
var key = builder.Configuration["Jwt:Key"];
var issuer = builder.Configuration["Jwt:Issuer"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

builder.Services.AddAuthorization();


// Cors Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "react-app-client",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}


app.UseCors("react-app-client");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
