using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olp.ProcessingService.Core.Contracts.Proposal
{
    public class ProposalDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
