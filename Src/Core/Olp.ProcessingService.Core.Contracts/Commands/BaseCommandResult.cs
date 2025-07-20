using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Olp.ProcessingService.Core.Contracts.Commands
{
    public class BaseResultDto : BaseDto
    {
    }

    public class BaseCommandResult
    {
        public required BaseCommand Command { get; set; }
        public virtual BaseResultDto? Result { get; set; }
    }

    public class BaseCommandResult<T> : BaseCommandResult
        where T : BaseResultDto
    {
        public override BaseResultDto? Result
        {
            get { return Data; }
            set { Data = (T?)value; }
        }

        [JsonIgnore]
        public T? Data { get; set; }
    }
}
