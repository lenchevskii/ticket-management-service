using TicketManagement.BL.Models;
using TicketManagement.BL.Models.Response;

namespace TicketManagement.BL.Services
{
  public class TicketManagementService
  {
    private readonly Anonymous _anonymous;

    public TicketManagementService() => _anonymous = new Anonymous();

    public TicketManagementServiceResponse ImplemntAnonymousService()
    {
      TicketManagementServiceResponse ticketManagementServiceResponse = new TicketManagementServiceResponse
      {
        AvaliableSeats = _anonymous.GetAvaliableSeats(),
        UserEvents = _anonymous.GetAllFormRepository(),
      };

      return ticketManagementServiceResponse;
    }
  }
}
