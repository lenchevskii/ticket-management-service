using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagement.DAL
{
  [Table("Area")]
  public class Area
  {
    public Area()
    {
    }

    public Area(int layoutId, int coordX, int coordY, string description)
    {
      LayoutId = layoutId;
      CoordX = coordX;
      CoordY = coordY;
      Description = description;
    }

    public int Id { get; set; }

    public int LayoutId { get; set; }

    [Required]
    [StringLength(200)]
    public string Description { get; set; }

    public int CoordX { get; set; }

    public int CoordY { get; set; }
  }
}
