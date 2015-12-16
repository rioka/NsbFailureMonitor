
using System.Reflection;
using NServiceBus;

namespace NsbFailureMonitor.Server
{
  public class EndpointConfig : IConfigureThisEndpoint
  {
    public void Customize(BusConfiguration configuration)
    {
      configuration.EndpointName(MethodBase.GetCurrentMethod().DeclaringType.Namespace);

      configuration.UseTransport<MsmqTransport>();
      configuration.UsePersistence<InMemoryPersistence>();
      configuration.UseSerialization<JsonSerializer>();

      configuration.Conventions()
          .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Commands"))
          .DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Events"))
          .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages"));
    }
  }
}
