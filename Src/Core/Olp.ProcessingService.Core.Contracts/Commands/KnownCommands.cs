using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olp.ProcessingService.Core.Contracts.Commands
{
    public static class KnownCommands
    {
        public static KnownCommand CreateProposal = new KnownCommand
        {
            Name = nameof(CreateProposal)
        };
    }

    public class KnownCommand
    {
        public required string Name { get; set; }
    }
}
