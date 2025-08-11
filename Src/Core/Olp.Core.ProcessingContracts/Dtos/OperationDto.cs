namespace Olp.Core.ProcessingContracts.Dtos;

public class OperationDto : BaseDto
{
    public required string Name { get; set; }
    public required string Status { get; set; }
}
