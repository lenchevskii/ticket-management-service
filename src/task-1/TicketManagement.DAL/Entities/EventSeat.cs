using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagement.DAL
{
  [Table("EventSeat")]
  public class EventSeat
  {
    public EventSeat()
    {
    }

    public EventSeat(int eventAreaId, int row, int number, int state)
    {
      EventAreaId = eventAreaId;
      Row = row;
      Number = number;
      State = state;
    }

    public int EventAreaId { get; set; }

    public int Row { get; set; }

    public int Number { get; set; }

    public int State { get; set; }
  }
}
