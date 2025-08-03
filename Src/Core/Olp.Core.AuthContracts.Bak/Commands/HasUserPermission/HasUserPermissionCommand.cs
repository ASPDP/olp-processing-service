namespace Olp.AuthService.Core.Contracts.Commands.HasUserPermission;

public class HasUserPermissionCommand() : BaseCommand("HasUserPermission")
{
    public required HasUserPermissionCommandParams Params { get; set; }
}
