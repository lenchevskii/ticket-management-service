using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagement.DAL
{
  [Table("Seat")]
  public class Seat
  {
    public Seat()
    {
    }

    public Seat(int areaId, int row, int number)
    {
      AreaId = areaId;
      Row = row;
      Number = number;
    }

    public int Id { get; set; }

    public int AreaId { get; set; }

    public int Row { get; set; }

    public int Number { get; set; }
  }
}
