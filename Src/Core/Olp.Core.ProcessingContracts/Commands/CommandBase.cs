namespace Olp.Core.ProcessingContracts.Commands;


public class CommandBase(string name)
{
    public string Name { get; } = name;
}
