using API.Endpoints;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGroup("/api/v1")
    .WithTags("API v1")
    .MapBoardsEndpoints();

app.UseHttpsRedirection();


app.Run();