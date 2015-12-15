using System;

namespace NsbFailureMonitor.Messages.Events
{
  public class OrderCreated
  {
    public Guid OrderId { get; set; }
  }
}
