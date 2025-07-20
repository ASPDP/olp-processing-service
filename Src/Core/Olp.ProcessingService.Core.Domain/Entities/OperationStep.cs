using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Olp.ProcessingService.Core.Domain.Entities
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
