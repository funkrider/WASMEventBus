using MediatR;

namespace WASMEventBus.Shared;

public record CounterQuery(int Count) : IRequest<ServerCount>, IRemoteableRequest;

public record ServerCount(int NewCount, string? ServerProcessName);
