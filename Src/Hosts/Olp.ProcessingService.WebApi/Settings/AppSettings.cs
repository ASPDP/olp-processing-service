using Olp.Infrastructure.EntityFramework.ProcessingContext.Settings;


namespace Olp.ProcessingService.WebApi.Settings;

public class AppSettings
{
    public required DbSettings DbSettings { get; set; }
    public required ProposalServiceSettings ProposalServiceSettings { get; set; }
}
