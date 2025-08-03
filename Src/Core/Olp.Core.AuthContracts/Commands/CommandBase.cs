namespace Olp.Core.AuthContracts.Commands;

public class CommandBase(string name)
{
    public string Name { get; } = name;
}
