using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Olp.ProcessingService.Core.Domain.Enums;

namespace Olp.ProcessingService.Core.Domain.Entities
{
    public class Operation : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ProposalId { get; set; }
        public Guid OptionId { get; set; }

        public required string Name { get; set; }
        public OperationStatus Status { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string? ErrorMessage { get; set; }

        public Guid CurrentStepId { get; set; }
        public OperationStep? CurrentStep { get; set; }

        public virtual List<OperationStep> OperationSteps { get; set; } = new List<OperationStep>();

    }
}
