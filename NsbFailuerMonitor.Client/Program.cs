using System;
using System.Configuration;
using System.Linq;
using NsbFailureMonitor.Messages.Commands;
using NServiceBus;

namespace NsbFailuerMonitor.Client
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      ServiceBus.Init();
      var bus = ServiceBus.Bus;

      var names = ConfigurationManager.AppSettings["Customers"].Split(';');
      var rgn = new Random();

      while (true)
      {
        Console.WriteLine("Enter the amount for the order\nSet amount to 1 to get an exception processing the order\nSet amount to 0 to quit");

        var input = (Console.ReadLine() ?? "").ToUpper();

        decimal amount;
        if (string.IsNullOrWhiteSpace(input) || !decimal.TryParse(input, out amount) || amount == 0)
        {
          break;
        }

        bus.Send(new CreateOrder() {
          Customer = names[rgn.Next(names.Count() - 1)],
          City = "Manchester",
          Country = "England",
          PostCode = "AS212",
          Street = "5 Holland Drive",
          Amount = amount
        });

        Console.WriteLine("New order sent");
      }

      bus.Dispose();
    }
  }
}
