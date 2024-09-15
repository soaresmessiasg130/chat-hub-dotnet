using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;

class GeneralChatHub : Hub
{
  public async IAsyncEnumerable<DateTime> Streaming([EnumeratorCancellation] CancellationToken cancellationToken)
  {
    while (true)
    {
      yield return DateTime.UtcNow;

      await Task.Delay(1000, cancellationToken);
    }
  }
}
