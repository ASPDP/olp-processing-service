namespace Olp.AuthService.Core.Contracts.Commands;

public class BaseCommand(string name)
{
    public string Name { get; } = name;
}
