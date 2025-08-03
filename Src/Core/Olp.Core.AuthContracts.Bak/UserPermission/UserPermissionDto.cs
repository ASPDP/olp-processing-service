namespace Olp.AuthService.Core.Contracts.Permission;

public class UserPermissionDto
{
    public Guid UserId { get; set; }

    public required string PermissionName { get; set; }
}
