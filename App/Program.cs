using System.Text;
using App.Identity;
using Business.Abstract;
using Data;
using Data.Concrete;
using Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ReservationContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnectionString"));
});

builder.Services.AddDbContext<ApplicationContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnectionString"));
});

builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options => {
    // password
    options.Password.RequireDigit = true; 
    options.Password.RequireLowercase = true; 
    options.Password.RequireUppercase = true; 
    options.Password.RequiredLength = 6; 
    options.Password.RequireNonAlphanumeric = true; 

    // lockout
    options.Lockout.MaxFailedAccessAttempts = 5; 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); 
    options.Lockout.AllowedForNewUsers = true; 

    options.User.RequireUniqueEmail = true; 
    options.SignIn.RequireConfirmedEmail = true; 
    options.SignIn.RequireConfirmedPhoneNumber = false; 
});

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddScoped<IHotelService,HotelManager>();
builder.Services.AddScoped<IRoomService,RoomManager>();
builder.Services.AddScoped<ICityService,CityManager>();
builder.Services.AddScoped<ICompanyService,CompanyManager>();

builder.Services.AddCors(options => 
{
    options.AddPolicy(
        name: "_myAllowOrigins",
        builder => {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

builder.Services.AddAuthentication(auth => {
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["AuthSettings:Audince"],
        ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:Key"]!)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("_myAllowOrigins");

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

var configur = builder.Configuration;

IdentitySeed.Seed(app,configur);

app.Run();
