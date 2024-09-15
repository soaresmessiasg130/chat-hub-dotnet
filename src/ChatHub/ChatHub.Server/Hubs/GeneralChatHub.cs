using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;

namespace ChatHub.Server.Hubs;

public class GeneralChatHub : Hub<IGeneralChatHub>
{
  public string GetConnectionId()
  {
    return Context.ConnectionId;
  }

  public override async Task OnConnectedAsync()
  {
    await Clients.All.SendMessageToAllAsync($"New connection, thanks: {Context.ConnectionId}");
  }

  public async IAsyncEnumerable<DateTime> Streaming([EnumeratorCancellation] CancellationToken cancellationToken)
  {
    while (true)
    {
      yield return DateTime.UtcNow;

      await Task.Delay(1000, cancellationToken);
    }
  }
}

public interface IGeneralChatHub
{
  Task SendMessageToAllAsync(string message);
}
