using MediatR;
using Microsoft.AspNetCore.Components;

namespace WASMEventBus.Shared;

public class Bus : IBus
{
    public Bus(IMediator mediator)
    {
        Mediator = mediator;
    }

    [Inject]
    private IMediator Mediator { get; set; }
    
    public virtual async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        return await Mediator.Send(request);
    }

    public async Task<object?> Send(object request)
    {
        return await Mediator.Send(request);
    }

    public void Publish<TNotification>(TNotification notification) where TNotification : INotification
    {
        Mediator.Publish(notification);
    }
}