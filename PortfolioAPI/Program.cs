using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PortfolioAPI.Data;
using PortfolioAPI.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    // Definición de seguridad: cómo se envía el token
    setupAction.AddSecurityDefinition("PortfolioApiAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Introduce el token JWT generado al iniciar sesión. Ejemplo: Bearer {tu_token}"
    });

    // Requerimiento de seguridad: indica a Swagger que use el esquema anterior
    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "PortfolioApiAuth" // debe coincidir con el nombre definido arriba
                }
            },
            new List<string>()
        }
    });
});


builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:sqlliteConnection"]
        )    
    );
builder.Services.AddAuthentication("Bearer") // "Bearer" es el esquema de autenticación
    .AddJwtBearer(options =>
    {
        // Configuramos cómo se validará el token
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // valida quién emite el token
            ValidateAudience = true, // valida quién puede usarlo
            ValidateIssuerSigningKey = true, // valida la firma con la clave secreta
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"])
            )
        };
    });


builder.Services.AddScoped<ExperienceRepository>();
builder.Services.AddScoped<UserRepository>();

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