using EasyNetQ;

using Olp.Core.AuthContracts.Commands;
using Olp.Infrastructure.EventBus.Interfaces;


namespace Olp.Infrastructure.EventBus.AuthContracts.EventMessages;

[Queue(Name = "Olp.Auth.HasUserPermissionEvent")]
public class HasUserPermissionEvent : IEventMessage
{
    public Guid OperationStepId { get; set; }
    public string Action { get; set; } = "Command";
    public required HasUserPermissionCommand Command { get; set; }
}
