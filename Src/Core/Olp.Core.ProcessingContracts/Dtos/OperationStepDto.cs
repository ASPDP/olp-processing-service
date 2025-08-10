namespace Olp.Core.ProcessingContracts.Dtos;

public class OperationStepDto : BaseDto
{
    public required string Name { get; set; }
    public required string Status { get; set; }
}
