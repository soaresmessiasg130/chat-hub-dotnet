using Microsoft.AspNetCore.SignalR.Client;

var uri = "http://localhost:5287/generalchathub";

await using var connection = new HubConnectionBuilder()
  .WithUrl(uri)
  .Build();

await connection.StartAsync();

connection.On<string>("SendMessageToAllAsync", s =>
{
  Console.WriteLine($"My ID: {connection.ConnectionId}");
  Console.WriteLine($"Notification: {s}");
});

await foreach (var date in connection.StreamAsync<DateTime>("Streaming"))
{
  Console.WriteLine(date);
}
