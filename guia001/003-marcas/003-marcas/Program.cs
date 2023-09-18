var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var marcas = new List<Marcas>();

app.MapGet("/marcas", () =>
{
    return marcas;
});

app.MapPut("/marcas/{id}", (int id, Marcas marca) =>
{
    var existingMarcas = marcas.FirstOrDefault(x => x.Id == id);
    if (existingMarcas != null)
    {
        existingMarcas.Name = marca.Name;
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("/marcas/", (Marcas marca) =>
{
    marcas.Add(marca);
    return Results.Ok();
});

app.Run();

internal class Marcas
{
    public int Id { get; set; }
    public string Name { get; set; }
}