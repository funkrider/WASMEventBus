# WASMEventBus

This is a proof of concept solution that was created directly from a presentation by ClearMeasure and Jeffrey Palermo on Blazor Architecture patterns.

During his demo he showed how to use an event bus pattern with both client and server Blazor applications. The rationale is that by implementing an event bus your application components remain decoupled. However the client WASM Blazor app must communicate with the server in order to fetch data. This is traditionally done with a public API. By creating an interface for the event bus you can define a different service for the client WASM version of your app that dispatches events back to the server using an HttpClient. Messages are serialized into JSON and responses come back as JSON are are de-serialized automatically. This lets your Blazor components be un-aware of any API endpoints and for the same event to be used on either client or server implementaitons of Blazor.
