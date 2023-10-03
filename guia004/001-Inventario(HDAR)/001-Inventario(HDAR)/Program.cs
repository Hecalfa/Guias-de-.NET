using _001_Inventario_HDAR_.Auth;
using _001_Inventario_HDAR_.Endpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT API", Version = "v1" });

    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Ingrese tu token  de JWT Autenticacion",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecuritySheme, Array.Empty<string>() } });
});
builder.Services.AddAuthorization(Options =>
{
    Options.AddPolicy("LoggedInPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

var key = "key.JWTAPIMinimal.API";

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

//builder.Services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));
builder.Services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddAccountEndpoints();
app.AddBodegaEndpoint();
app.AddCategoriaProductoEndpoint();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();