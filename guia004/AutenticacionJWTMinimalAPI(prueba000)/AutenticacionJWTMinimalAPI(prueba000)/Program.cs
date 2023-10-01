using AutenticacionJWTMinimalAPI_prueba000_;
using AutenticacionJWTMinimalAPI_prueba000_.Auth;
using AutenticacionJWTMinimalAPI_prueba000_.Endpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT API", Version = "v1" });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Ingrese tu token de JWT Authentication",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("loggetIPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

var key = "Key.JWTAPIMinimal2023.API";

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(x =>
 {
     x.RequireHttpsMetadata = false;

     x.SaveToken = true;

     x.TokenValidationParameters = new TokenValidationParameters
     {
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),

         ValidateAudience = false,

         ValidateIssuerSigningKey = true,

         ValidateIssuer = false
     };
 });

builder.Services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddAccountEndpoints();
app.AddProtectedEndpoints();
app.AddTestEndpoints();

app.UseAuthentication();
app.UseAuthorization();

app.Run();