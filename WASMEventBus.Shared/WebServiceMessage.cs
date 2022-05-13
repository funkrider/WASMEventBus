using System.Text.Json;

namespace WASMEventBus.Shared;

public class WebServiceMessage
{
    
    public string Body { get; set; } = String.Empty;
    public string TypeName { get; set; } = String.Empty;
    
    public WebServiceMessage()
    {
    }
    
    public WebServiceMessage(object request)
    {
        Body = GetBody(request);
        TypeName = request.GetType().FullName +
                   ", " +
                   request.GetType().Assembly.GetName().Name;
    }
    
    public string GetBody(object request)
    {
        var body = JsonSerializer.Serialize(request, request.GetType());
        return body;
    }

    public string GetJson()
    {
        var json = JsonSerializer.Serialize(this);
        return json;
    }

    public TReturn GetBodyObject<TReturn>()
    {
        Type type = typeof(TReturn);
        string value = Body;
        return (TReturn)JsonSerializer.Deserialize(value, type);
    }
 
    public object GetBodyObject()
    {
        Type type = Type.GetType(TypeName, true);
        string value = Body;
        return JsonSerializer.Deserialize(value, type);
    }
}