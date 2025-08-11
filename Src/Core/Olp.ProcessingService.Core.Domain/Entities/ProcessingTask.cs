using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olp.ProcessingService.Core.Domain.Entities
{
    public class ProcessingTask
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Payload { get; set; } // вот данные для обработки
    }
}
