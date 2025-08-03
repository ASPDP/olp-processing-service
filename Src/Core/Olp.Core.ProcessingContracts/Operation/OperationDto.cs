namespace Olp.Core.ProcessingContracts.Operation;

public class OperationDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Status { get; set; }
}
