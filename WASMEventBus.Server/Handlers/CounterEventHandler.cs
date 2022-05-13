using System.Diagnostics;
using MediatR;
using WASMEventBus.Shared;

namespace WASMEventBus.Server.Handlers;

public class CounterEventHandler : IRequestHandler<CounterQuery, ServerCount>
{
    public Task<ServerCount> Handle(CounterQuery request, CancellationToken cancellationToken)
    {
        var serverProcessName = Process.GetCurrentProcess().ProcessName;
        var serverCount = new ServerCount(request.Count + 2, serverProcessName);
        return Task.FromResult(serverCount);
    }
}