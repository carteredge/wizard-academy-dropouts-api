using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using WizardAcademyDropouts.Domain;
using WizardAcademyDropouts.Maps;
using WizardAcademyDropouts.Middleware;
using WizardAcademyDropouts.Services;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddIdentityServer(/*options => { }*/);
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "cookie";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie("cookie", options =>
    {
        options.Cookie.Name = "DropoutsCookie";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.SlidingExpiration = true;
    })
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://localhost:5001"; // TODO: Get from env
        options.ClientId = "web";
        options.ClientSecret = Environment.GetEnvironmentVariable("DropoutsIdentityClientSecret");
        // options.ClientSecret = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("DropoutsIdentityClientSecret"))).Select(item => item.ToString("x2")).ToString();
        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("email");
        // options.Scope.Add("dropoutsApi");
        options.MapInboundClaims = false; // Don't rename claim types
        options.SaveTokens = true;
        options.ResponseType = "code";
        options.UsePkce = true;
    });
    // .AddJwtBearer(options =>
    // {
    //     options.Authority = "https://localhost:5001"; // TODO: Get from env
    //     options.TokenValidationParameters.ValidateAudience = false;
    // });

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowSpecificOrigins", builder =>
    {
        builder.AllowCredentials();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
        builder.WithOrigins("https://localhost:8081"); // TODO: Get from env
    });
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
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("allowSpecificOrigins");

app.UseResponseHandler();

app.MapCharacterEndpoints();
app.MapGet("identity", (ClaimsPrincipal user) => user.Claims.Select(c => new { c.Type, c.Value })).RequireAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v0.1/swagger.json", "Wizard Academy Dropouts API v0.1");
});

app.Run();
