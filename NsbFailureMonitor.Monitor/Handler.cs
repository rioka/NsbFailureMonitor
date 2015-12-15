using System;
using NServiceBus;
using ServiceControl.Contracts;

namespace NsbFailureMonitor.Monitor
{
  public class Handler : IHandleMessages<MessageFailed>
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
  }
}
