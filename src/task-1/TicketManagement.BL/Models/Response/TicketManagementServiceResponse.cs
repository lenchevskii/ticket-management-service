using System.Collections.Generic;
using TicketManagement.DAL;

namespace TicketManagement.BL.Models.Response
{
  public class TicketManagementServiceResponse
  {
    public IEnumerable<UserEvent> UserEvents { get; set; }

    public IEnumerable<Seat> AvaliableSeats { get; set; }
  }
}
