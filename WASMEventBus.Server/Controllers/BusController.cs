using Microsoft.AspNetCore.Mvc;
using WASMEventBus.Shared;

namespace WASMEventBus.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusController : ControllerBase
{

    private readonly IBus _bus;

    public BusController(IBus bus)
    {
        _bus = bus;
    }
    
    [HttpPost]
    public async Task<string> Post(WebServiceMessage message)
    {
        var result = await _bus.Send(message.GetBodyObject()) 
                     ?? throw new InvalidOperationException("Message type not recognised!");

        return new WebServiceMessage(result).GetJson();
    }
}