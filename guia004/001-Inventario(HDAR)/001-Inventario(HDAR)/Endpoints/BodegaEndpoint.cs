using _001_Inventario_HDAR_.Models;
using System.ComponentModel.DataAnnotations;

namespace _001_Inventario_HDAR_.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<bodega> data = new List<bodega>();

        public static void AddBodegaEndpoint(this WebApplication app)
        {
            app.MapGet("/bodega", () =>
            {
                return data;
            }).RequireAuthorization();

            app.MapPost("/bodega", (int Id,string Name, string Description) =>
            {
                data.Add(new bodega { Id = Id, Name = Name,Description = Description});
                return Results.Ok();
            }).RequireAuthorization();

            app.MapPut("/bodega/{Id}",(int Id, string Name, string Description)=> 
           {

                var existingBodega = data.FirstOrDefault(b => b.Id == Id);
                if (existingBodega != null)
                {
                    existingBodega.Name = Name;
                    existingBodega.Description = Description;
                }
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
