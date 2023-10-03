namespace _001_Inventario_HDAR_.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddCategoriaProductoEndpoint(this WebApplication app)
        {
            app.MapGet("/categoria", () =>
            {
                return data;
            }).AllowAnonymous();

            app.MapPost("/categoria", (string name, string producto) =>
            {
                data.Add(new { name, producto });
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
