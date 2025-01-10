using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WizardAcademyDropouts.Domain;
using WizardAcademyDropouts.Maps;
using WizardAcademyDropouts.Middleware;
using WizardAcademyDropouts.Services;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddIdentityServer(/*options => { }*/);
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001"; // TODO: Get from env
        options.TokenValidationParameters.ValidateAudience = false;
    });
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v0.1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Wizard Academy Dropouts API",
        Description = "API resources for the tabletop roleplaying game Wizard Academy Dropouts",
        Version = "v0.1"
    });
});
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSingleton<IConfiguration, ConfigurationManager>();

// var dbUser = builder.Configuration["SaUser"];
// var dbPassword = builder.Configuration["SaPassword"];

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<DropoutsDBContext>(options => options.UseSqlServer(connectionString));

// builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<CharacterService>();

var app = builder.Build();

app.UseRouting();



// app.UseIdentityServer();
app.UseAuthorization();

app.UseResponseHandler();

app.MapCharacterEndpoints();
app.MapGet("identity", (ClaimsPrincipal user) => user.Claims.Select(c => new { c.Type, c.Value })).RequireAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v0.1/swagger.json", "Wizard Academy Dropouts API v0.1");
});

app.Run();
