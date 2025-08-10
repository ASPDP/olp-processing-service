namespace Olp.Core.AuthContracts.Commands;


public class HasUserPermissionCommandResult
{
    public bool Success { get; set; }
    public bool HasUserPermission { get; set; }
}

