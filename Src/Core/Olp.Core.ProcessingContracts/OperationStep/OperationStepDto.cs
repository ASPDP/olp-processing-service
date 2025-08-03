namespace Olp.Core.ProcessingContracts.OperationStep;

internal class OperationStepDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Status { get; set; }
}
