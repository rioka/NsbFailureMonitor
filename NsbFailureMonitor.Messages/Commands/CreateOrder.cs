
using System;

namespace NsbFailureMonitor.Messages.Commands
{
  public class CreateOrder
  {
    public string Customer { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public decimal Amount { get; set; }
  }
}
