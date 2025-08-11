namespace Olp.Core.AuthContracts.Commands;

public class HasUserPermissionCommand() : CommandBase(nameof(HasUserPermissionCommand))
{
    public required HasUserPermissionCommandParams Params { get; set; }
}
