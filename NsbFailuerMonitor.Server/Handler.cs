using System;
using NServiceBus;
using NsbFailureMonitor.Messages.Commands;

namespace NsbFailuerMonitor.Server
{
  public class Handler : IHandleMessages<CreateOrder>
  {
    public IBus Bus { get; set; }
    
    public void Handle(CreateOrder message)
    {
      Console.WriteLine("New order from customer '{0}' received (amount {1})", message.Customer, message.Amount);

      if (message.Amount == 1)
      {
        throw new Exception(string.Format("Forced exception for order by '{0}' and amount {1:#,##0.00}", message.Customer, message.Amount));
      }
    }
  }
}
