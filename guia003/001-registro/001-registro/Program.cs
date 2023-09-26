using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(opcion =>
 {
     opcion.ReturnUrlParameter = "unauthorized";
     opcion.Events = new CookieAuthenticationEvents
     {
         OnRedirectToLogin = context =>
         {
             context.Response.StatusCode = StatusCodes.Status401Unauthorized;
             context.Response.ContentType = "applicacion/json";
             var message = new
             {
                 error = "No autisado",
                 message = "Debe inicar sesecion para acceder a este recurso."
             };
             var JsonMessage = JsonSerializer.Serialize(message);
             return context.Response.WriteAsync(JsonMessage);
         }
     };
 });
var app  = builder.Build();
if  (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();