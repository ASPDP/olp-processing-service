using EasyNetQ;
using Olp.AuthService.Core.Contracts.Commands.HasUserPermission;
using Olp.Infrastructure.EventBus.Interfaces;

namespace Olp.Infrastructure.EventBus.AuthContracts;

[Queue(Name = "Olp.Auth.HasUserPermissionResponse")]
public class HasUserPermissionEventResult : IMessageBase
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
