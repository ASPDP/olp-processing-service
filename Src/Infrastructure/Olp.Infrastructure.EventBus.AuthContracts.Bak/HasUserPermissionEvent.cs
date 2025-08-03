using EasyNetQ;
using Olp.AuthService.Core.Contracts.Commands.HasUserPermission;
using Olp.Infrastructure.EventBus.Interfaces;

namespace Olp.Infrastructure.EventBus.AuthContracts;

[Queue(Name = "Olp.Auth.HasUserPermissionEvent")]
public class HasUserPermissionEvent : IMessageBase
{
    public Guid OperationStepId { get; set; }
    public string Action { get; set; } = "Command";
    public required HasUserPermissionCommand Command { get; set; }
}
