namespace Olp.Core.AuthContracts.Commands;

public class HasUserPermissionCommandParams
{
    public Guid UserId { get; set; }
    public required string PermissionName { get; set; }
}
