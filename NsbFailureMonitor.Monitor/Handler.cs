using System;
using NServiceBus;
using ServiceControl.Contracts;

namespace NsbFailureMonitor.Monitor
{
  public class Handler : IHandleMessages<MessageFailed>
  {
    public void Handle(MessageFailed message)
    {
      Console.WriteLine("Message {0} failed to process", message.MessageType);
    }
  }
}
