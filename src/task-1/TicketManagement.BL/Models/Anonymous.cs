using System.Collections.Generic;
using System.Linq;
using TicketManagement.DAL;
using TicketManagement.DAL.Data;

namespace TicketManagement.BL.Models
{
  public class Anonymous
  {
    private readonly UserEventRepository _userEventRepository;
    private readonly SeatRepository _seatRepository;
    private readonly EventSeatRepository _eventSeatRepository;

    public Anonymous()
    {
      _userEventRepository = new UserEventRepository();
      _seatRepository = new SeatRepository();
      _eventSeatRepository = new EventSeatRepository();
    }

    public IEnumerable<UserEvent> GetAllFormRepository() => _userEventRepository.GetAllAsync().Result;

    public IEnumerable<Seat> GetAvaliableSeats()
    {
      IList<Seat> allSeats = _seatRepository.GetAllAsync().Result.ToList();
      IList<EventSeat> allEventSeats = _eventSeatRepository.GetAllAsync().Result.ToList();
      IList<Seat> allSeatsFromEventSeats = new List<Seat>();
      IList<Seat> response = new List<Seat>();
      IEqualityComparer<Seat> comparer = new SeatComparer();

      foreach (var eventSeat in allEventSeats)
      {
        allSeatsFromEventSeats.Add(new Seat(eventSeat.EventAreaId, eventSeat.Row, eventSeat.Number));
      }

      foreach (var seat in allSeats)
      {
        if (!allSeatsFromEventSeats.Contains<Seat>(seat, comparer))
        {
          response.Add(seat);
        }
      }

      return response;
    }
  }
}
