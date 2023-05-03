using Microsoft.EntityFrameworkCore;
using DAT154_Oblig4_RestAPI.Data;
using DAT154_Oblig4_RestAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Mvc;

namespace DAT154_Oblig4_RestAPI;

public static class RoomEndpoints
{
    public static void MapRoomEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Room").WithTags(nameof(Room));

        group.MapGet("/", async ([FromServices] Dat154oblig4Context db) =>
        {
            return await db.Rooms.ToListAsync();
        })
        .WithName("GetAllRooms")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Room>, NotFound>> (int id, [FromServices] Dat154oblig4Context db) =>
        {
            return await db.Rooms.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Room model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetRoomById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromBody] Room room, [FromServices] Dat154oblig4Context db) =>
        {
            var affected = await db.Rooms
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Number, room.Number)
                  .SetProperty(m => m.Beds, room.Beds)
                  .SetProperty(m => m.Size, room.Size)
                  .SetProperty(m => m.Quality, room.Quality)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateRoom")
        .WithOpenApi();

        group.MapPost("/", async ([FromBody] Room room, [FromServices] Dat154oblig4Context db) =>
        {
            db.Rooms.Add(room);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Room/{room.Id}",room);
        })
        .WithName("CreateRoom")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromServices] Dat154oblig4Context db) =>
        {
            var affected = await db.Rooms
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteRoom")
        .WithOpenApi();
    }
}
