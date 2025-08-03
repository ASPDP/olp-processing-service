using EasyNetQ;

using Olp.Core.AuthContracts.Commands;
using Olp.Infrastructure.EventBus.Interfaces;


namespace Olp.Infrastructure.EventBus.AuthContracts.EventMessages;

[Queue(Name = "Olp.Auth.HasUserPermissionResponse")]
public class HasUserPermissionEventResult : IEventMessage
{
    public Guid OperationStepId { get; set; }
    public string Action { get; set; } = "Event";
    public required HasUserPermissionCommand Command { get; set; }
    public required HasUserPermissionCommandResult Result { get; set; }
}

public class HasUserPermissionCommandResult
{
    public bool Success { get; set; }
    public bool HasUserPermission { get; set; }
}
