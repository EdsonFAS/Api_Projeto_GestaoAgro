using System.Text.Json.Serialization;
using System.Text;
using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.WriteIndented = true;
});

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
           ValidIssuer = builder.Configuration["Jwt:Issuer"],
           ValidAudience = builder.Configuration["Jwt:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty)
           )
       };

       // Tratamento de erro personalizado
       options.Events = new JwtBearerEvents
       {
           OnAuthenticationFailed = context =>
           {
               context.Response.StatusCode = StatusCodes.Status401Unauthorized;
               context.Response.ContentType = "application/json";
               return context.Response.WriteAsync("{\"error\":\"Falha na autenticação. Token inválido ou expirado.\"}");
           },
           OnChallenge = context =>
           {
               context.HandleResponse(); // Impede a resposta padrão
               context.Response.StatusCode = StatusCodes.Status401Unauthorized;
               context.Response.ContentType = "application/json";
               return context.Response.WriteAsync("{\"error\":\"Acesso negado. Token ausente ou inválido.\"}");
           }
       };
   });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UsuarioAutenticado", policy =>
        policy.RequireAuthenticatedUser());
});

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // Ativa suporte às anotações
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Gestão Agro API",
        Description = "API de consumo para aplicação Gestão Agro"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Cabeçalho de autorização JWT. Usando esquema de Bearer \r\n\r\n Digite 'Bearer' antes de colocar o token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
         new OpenApiSecurityScheme
         {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
         },
         Array.Empty<string>()
        }
    });
});

// Busca string de conex�o e adiciona a classe AppDbContext Service do EF
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

// Configure the HTTP request pipeline.
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