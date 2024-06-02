
using API.Data;
using API.DTO;
using API.Interface;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Entities;
using AutoMapper;
using API.Helpers;

var builder = WebApplication.CreateBuilder(args);

//Add builder.services to container

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

// builder.Services.AddIdentity<UserEntity,IdentityRole>()
//         .AddEnt<ApplicationDbContext>()
//         .AddDefaultTokenProviders();

// Configure authentication services (without this bearer token will not be validate)

 
  builder.Services.AddIdentityCore<AppUser>(opt =>{
              opt.Password.RequireNonAlphanumeric = false;                
         })
             .AddRoles<IdentityRole<int>>()
            .AddRoleManager<RoleManager<IdentityRole<int>>>()
            .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<DataContext>();
                
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddScoped<ITokenService, TokenService>();


var tokenKey = builder.Configuration["TokenKey"];
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

////////////////


///Configure the HTTP Request Pipline
///
var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(policy => policy
.AllowAnyHeader()
.AllowCredentials() // For SigleR Chat
.AllowAnyMethod()
.WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();


app.MapControllers();

//app.MapFallbackToController("Index", "Fallback");




await app.RunAsync();

