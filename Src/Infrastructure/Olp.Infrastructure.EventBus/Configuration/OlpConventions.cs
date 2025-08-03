using EasyNetQ;

namespace Olp.Infrastructure.EventBus.Configuration
{
    public class OlpConventions : Conventions
    {
        public OlpConventions(ITypeNameSerializer typeNameSerializer) : base(typeNameSerializer)
        {
            ErrorQueueNamingConvention = messageInfo => "OlpErrorQueue";
        }
    }
}
