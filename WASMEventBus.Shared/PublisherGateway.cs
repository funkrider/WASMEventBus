using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace WASMEventBus.Shared;

public class PublisherGateway : IPublisherGateway
{

    private readonly HttpClient _httpClient;

    public PublisherGateway(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
    public async Task<WebServiceMessage?> Publish(IRemoteableRequest request)
    {
        var message = new WebServiceMessage(request);
        return await SendToTopic(message);
    }

    public async Task<WebServiceMessage?> SendToTopic(WebServiceMessage message)
    {
        string jsonContent = message.GetJson();
        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        var result = await _httpClient.PostAsync("/api/Bus", content);
        var json = await result.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<WebServiceMessage>(json);
    }
    
}