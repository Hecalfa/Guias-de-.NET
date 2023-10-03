namespace _001_Inventario_HDAR_.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddBodegaEndpoint(this WebApplication app)
        {
            app.MapGet("/bodega", () =>
            {
                return data;
            }).RequireAuthorization();

            app.MapPost("/bodega", (string name, string cajaProducto) =>
            {
                data.Add(new { name, cajaProducto });
                return Results.Ok();
            }).RequireAuthorization();

            ;app.MapDelete("/bodega", () =>
            {
                data = new List<object>();
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
