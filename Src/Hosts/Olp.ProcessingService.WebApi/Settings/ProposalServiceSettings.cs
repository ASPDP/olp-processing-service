namespace Olp.ProcessingService.WebApi.Settings
{
    public class ProposalServiceSettings
    {
        public string BaseUrl { get; set; }


        public Uri BaseAddress() => new Uri(BaseUrl);
    }
}
