using DAT154_Oblig4_RestAPI;
using DAT154_Oblig4_RestAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Dat154oblig4Context>(o => o.UseSqlServer("name=ConnectionStrings:DAT154Oblig4db"));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapReservationEndpoints();

app.MapRoomEndpoints();

app.MapTask_dbEndpoints();

app.MapUserEndpoints();

app.Run();
