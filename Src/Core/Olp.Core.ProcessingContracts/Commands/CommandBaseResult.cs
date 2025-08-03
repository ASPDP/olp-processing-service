using System.Text.Json.Serialization;


namespace Olp.Core.ProcessingContracts.Commands;

public class BaseResultDto : BaseDto
{
}

public class CommandBaseResult
{
    public required CommandBase Command { get; set; }
    public virtual BaseResultDto? Result { get; set; }
}

public class BaseCommandResult<T> : CommandBaseResult
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
