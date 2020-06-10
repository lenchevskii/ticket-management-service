using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagement.DAL
{
  [Table("Layout")]
  public class AreaLayout
  {
    public AreaLayout()
    {
    }

    public AreaLayout(int venueId, string description)
    {
      VenueId = venueId;
      Description = description;
    }

    public int Id { get; set; }

    public int VenueId { get; set; }

    [Required]
    [StringLength(120)]
    public string Description { get; set; }
  }
}
