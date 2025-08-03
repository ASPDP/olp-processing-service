namespace Olp.Core.ProcessingContracts.Commands;

public static class KnownCommands
{
    public static KnownCommand CreateProposal = new KnownCommand
    {
        Name = nameof(CreateProposal)
    };
}

public class KnownCommand
{
    public required string Name { get; set; }
}
