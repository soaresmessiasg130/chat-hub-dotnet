using ChatHub.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();

var app = builder.Build();

app.MapHub<GeneralChatHub>("/generalchathub");
app.MapControllers();

app.Run();
