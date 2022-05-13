namespace WASMEventBus.Shared;

public interface IPublisherGateway
{
    Task<WebServiceMessage?> Publish(IRemoteableRequest request);
    Task<WebServiceMessage?> SendToTopic(WebServiceMessage message);
}