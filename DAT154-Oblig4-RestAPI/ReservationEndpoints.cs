using Microsoft.EntityFrameworkCore;
using DAT154_Oblig4_RestAPI.Data;
using DAT154_Oblig4_RestAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Mvc;

namespace DAT154_Oblig4_RestAPI;

public static class ReservationEndpoints
{
    public static void MapReservationEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Reservation").WithTags(nameof(Reservation));

        group.MapGet("/", async ([FromServices] Dat154oblig4Context db) =>
        {
            return await db.Reservations.ToListAsync();
        })
        .WithName("GetAllReservations")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Reservation>, NotFound>> (int id, [FromServices] Dat154oblig4Context db) =>
        {
            return await db.Reservations.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Reservation model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetReservationById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromBody] Reservation reservation, [FromServices] Dat154oblig4Context db) =>
        {
            var affected = await db.Reservations
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.StartDate, reservation.StartDate)
                  .SetProperty(m => m.EndDate, reservation.EndDate)
                  .SetProperty(m => m.RoomId, reservation.RoomId)
                  .SetProperty(m => m.CustomerId, reservation.CustomerId)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateReservation")
        .WithOpenApi();

        group.MapPost("/", async ([FromBody] Reservation reservation, [FromServices] Dat154oblig4Context db) =>
        {
            db.Reservations.Add(reservation);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Reservation/{reservation.Id}",reservation);
        })
        .WithName("CreateReservation")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromServices] Dat154oblig4Context db) =>
        {
            var affected = await db.Reservations
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteReservation")
        .WithOpenApi();
    }
}
