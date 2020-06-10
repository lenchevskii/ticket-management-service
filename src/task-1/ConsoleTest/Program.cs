using System;
using TicketManagement.DAL;
using TicketManagement.DAL.Data;

namespace ConsoleTest
{
  internal static class Program
  {
    private static void Main()
    {
      EventSeat eventArea = new EventSeat(2, 2, 2, 1);

      var eventAreaRepo = new EventSeatRepository();

      // var eventAreaCreate = eventAreaRepo.CreateAsync(eventArea);

      // var eventAreaDelete = eventAreaRepo.DeleteRangeAsync(new[] { 11 });

      var eventAreaResponse = eventAreaRepo.GetAllAsync().Result;

      foreach (var item in eventAreaResponse)
      {
        Console.WriteLine("get item:");
        Console.WriteLine("\tID" + $"\t{item.State}" + "\tRow:" + $"\t{item.Row}" + "\tNumber:" + $"\t{item.Number}");
      }

      // TicketManagementService ticketManagementService = new TicketManagementService();

      // TicketManagementServiceResponse ticketManagementServiceResponce = ticketManagementService.ImplemntAnonymousService();

      // var avaliableSeats = ticketManagementServiceResponce.AvaliableSeats;

      // foreach (var item in avaliableSeats)
      // {
      //   Console.WriteLine("GET SEAT");
      //   Console.WriteLine("\tID" + $"\t{item.Id}" + "\tRow:" + $"\t{item.Row}" + "\tNumber:" + $"\t{item.Number}" + "\tAreaId:" + $"\t{item.AreaId}");
      // }

      Console.Read();
    }
  }
}
