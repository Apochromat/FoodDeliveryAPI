using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FoodDeliveryAPI.Models.Enums;
using FoodDeliveryAPI;
using System.Text.Json.Serialization;
using FoodDeliveryAPI.Services;
using Microsoft.IdentityModel.Tokens;
using FoodDeliveryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Add ability to right convert strings to enums
builder.Services.AddControllers().AddJsonOptions(opts => {
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});
// Add services
builder.Services.AddScoped<IAccountService, AccountService>();


// Connect DB
builder.Services.AddDbContext<ApplicationDbContext>();

// Add Identity
builder.Services.AddIdentity<User, Role>() // ƒобавление identity к проекту
    .AddEntityFrameworkStores<ApplicationDbContext>() // указание контекста
    .AddSignInManager<SignInManager<User>>() // €вное указание того, что менеджер авторизации должен работать с переопределенной моделью пользовател€
    .AddUserManager<UserManager<User>>() // аналогично дл€ менеджера юзеров
    .AddRoleManager<RoleManager<Role>>(); // аналогично дл€ менеджера ролей


// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option => {
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodDeliveryAPI", Version = "v1" });
    option.SchemaFilter<EnumSchemaFilter>();
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = JwtConfiguration.Issuer,
            ValidateAudience = true,
            ValidAudience = JwtConfiguration.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = JwtConfiguration.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,

        };
    });

var app = builder.Build();

using var serviceScope = app.Services.CreateScope();
var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
// auto migration
context.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();