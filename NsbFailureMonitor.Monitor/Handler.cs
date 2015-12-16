using System;
using NServiceBus;
using ServiceControl.Contracts;

namespace NsbFailureMonitor.Monitor
{
  public class Handler : IHandleMessages<MessageFailed>,
                         IHandleMessages<HeartbeatStopped>,
                         IHandleMessages<HeartbeatRestored>
  {
    public void Handle(MessageFailed message)
    {
      Console.WriteLine("Failure processing message {0}", message.MessageType);
      Console.WriteLine("\tError {0}", message.FailureDetails.Exception.Message);
      Console.WriteLine("\t# of attempts {0}", message.NumberOfProcessingAttempts);
      Console.WriteLine("\tProcessing endpoint {0}", message.ProcessingEndpoint.Name);
      Console.WriteLine("\tSending endpoint {0}", message.SendingEndpoint.Name);
      Console.WriteLine("\tSending endpoint {0}", message.Status);
    }

    public void Handle(HeartbeatStopped message)
    {
      Console.WriteLine("Endpoint '{0}' on host '{1}' seems not to be working at {2}", message.EndpointName, message.Host, message.DetectedAt.ToLocalTime());
    }

    public void Handle(HeartbeatRestored message)
    {
      Console.WriteLine("Endpoint '{0}' restored at {1} on host '{2}'", message.EndpointName, message.RestoredAt, message.Host);
    }
  }
}
