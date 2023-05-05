using Microsoft.EntityFrameworkCore;
using DAT154_Oblig4_RestAPI.Data;
using DAT154_Oblig4_RestAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Mvc;

namespace DAT154_Oblig4_RestAPI;

public static class Task_dbEndpoints
{
    public static void MapTask_dbEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Task").WithTags(nameof(Task_db));

        group.MapGet("/", async ([FromServices] Dat154oblig4Context db) =>
        {

            return await db.Tasks.ToListAsync();
        })
        .WithName("GetAllTasks").AllowAnonymous()
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Task_db>, NotFound>> (int id, [FromServices] Dat154oblig4Context db) =>
        {
            return await db.Tasks.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Task_db model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTaskById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromBody] Task_db task_db, [FromServices] Dat154oblig4Context db) =>
        {
            var affected = await db.Tasks
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Date, task_db.Date)
                  .SetProperty(m => m.Status, task_db.Status)
                  .SetProperty(m => m.Type, task_db.Type)
                  .SetProperty(m => m.Note, task_db.Note)
                  .SetProperty(m => m.RoomId, task_db.RoomId)
                  .SetProperty(m => m.StaffId, task_db.StaffId)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTask")
        .WithOpenApi();

        group.MapPost("/", async ([FromBody] Task_db task_db, [FromServices] Dat154oblig4Context db) =>
        {
            db.Tasks.Add(task_db);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Task/{task_db.Id}",task_db);
        })
        .WithName("CreateTask")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, [FromServices] Dat154oblig4Context db) =>
        {
            var affected = await db.Tasks
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTask")
        .WithOpenApi();
    }
}
