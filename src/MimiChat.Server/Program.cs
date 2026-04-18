using MimiChat.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(pc =>
{
    pc.WithOrigins((builder.Configuration["Cors:Origins"] ?? "").Split(","));
});

app.MapHub<ChatHub>("/chathub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
