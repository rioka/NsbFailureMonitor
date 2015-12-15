
using System.Reflection;
using NServiceBus;

namespace NsbFailureMonitor.Monitor
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
          .DefiningEventsAs(t => typeof(IEvent).IsAssignableFrom(t)
                                 || t.Namespace != null && t.Namespace.StartsWith("ServiceControl.Contracts"));
    }
  }
}
