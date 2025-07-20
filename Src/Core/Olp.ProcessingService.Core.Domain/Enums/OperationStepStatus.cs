using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olp.ProcessingService.Core.Domain.Entities
{
    public enum OperationStepStatus : byte
    {
        Pending,
        Processing,
        Succeeded,
        Failed,
        Compensated
    }
}
