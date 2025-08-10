using System.Text.Json.Serialization;

namespace Olp.Core.ProcessingContracts.Commands;

public class CommandBase(string name)
{
    public string Name => name;
}
