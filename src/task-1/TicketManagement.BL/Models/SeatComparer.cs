using System.Collections.Generic;
using TicketManagement.DAL;

namespace TicketManagement.BL.Models
{
  public sealed class SeatComparer : IEqualityComparer<Seat>
  {
    public bool Equals(Seat x, Seat y)
    {
      bool isAreaId = x.AreaId == y.AreaId;
      bool isNumber = x.Number == y.Number;
      bool isRow = x.Row == y.Row;

      return isAreaId && isNumber && isRow;
    }

    public int GetHashCode(Seat obj) => obj.GetHashCode();
  }
}
