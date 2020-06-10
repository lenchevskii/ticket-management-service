using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagement.DAL
{
  [Table("EventArea")]
  public class EventArea : Area
  {
    public EventArea()
    {
    }

    public EventArea(int eventId, string description, int coordX, int coordY, decimal price)
    {
      EventId = eventId;
      Description = description;
      CoordX = coordX;
      CoordY = coordY;
      Price = price;
    }

    public int EventId { get; set; }

    public decimal Price { get; set; }
  }
}
