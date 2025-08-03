namespace Olp.AuthService.Core.Contracts.Commands.HasUserPermission;

public class HasUserPermissionCommandParams
{
    public Guid UserId { get; set; }
    public required string PermissionName { get; set; }
}
