using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olp.ProcessingService.Core.Domain.Enums
{
    public enum OperationStatus : byte
    {
        Pending,
        Processing,
        Succeeded,
        Failed,
        Compensated
    }
}
