using Microsoft.AspNetCore.SignalR.Client;

try
{
    var connection = new HubConnectionBuilder()
    .WithUrl(Environment.GetEnvironmentVariable("SERVER_URL") ?? "http://localhost:5106/chathub")
    .Build();

    connection.On<string, string>("ReceiveMessage", (user, message) =>
    {
        Console.WriteLine($"[{user}]: {message}");
    });

    await connection.StartAsync();
    Console.WriteLine("Connection established with the server");

    while (true)
    {
        var prompt = Console.ReadLine()
            ?? throw new Exception("You must enter something.");

        if (prompt == "/exit")
        {
            await connection.StopAsync();
            break;
        }

        await connection.InvokeAsync("SendMessage", "user", prompt);
    }
}
catch (Exception)
{

    throw;
}
