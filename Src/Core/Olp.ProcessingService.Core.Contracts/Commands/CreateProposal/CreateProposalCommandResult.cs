using Olp.ProcessingService.Core.Contracts.Operation;
using Olp.ProcessingService.Core.Contracts.Proposal;

namespace Olp.ProcessingService.Core.Contracts.Commands.CreateProposal
{
    public class CreateProposalCommandResult : BaseResultDto
    {
        public required OperationDto Operation { get; set; } 
        public required ProposalDto Proposal { get; set; }
    }
}
