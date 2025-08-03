using Olp.Core.ProcessingDomain.Enums;


namespace Olp.Core.ProcessingDomain.Entities
{
    public class OperationStep : EntityBase<Guid>
    {
        public required string Name { get; set; }
        public OperationStepStatus Status { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string? ErrorMessage { get; set; }

        public Guid OperationId { get; set; }
        public Operation? Operation { get; set; }
    }
}
