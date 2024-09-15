using ChatHub.Server.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatHub.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeneralChatController : ControllerBase
{
  private readonly IHubContext<GeneralChatHub, IGeneralChatHub> _generalChatHubContext;

  public GeneralChatController(IHubContext<GeneralChatHub, IGeneralChatHub> generalChatHubContext)
  {
    this._generalChatHubContext = generalChatHubContext;
  }

  [HttpPost]
  public async Task<IActionResult> Post()
  {
    await _generalChatHubContext.Clients.All.SendMessageToAllAsync($"Notification: {DateTime.UtcNow}");

    return Ok();
  }
}
