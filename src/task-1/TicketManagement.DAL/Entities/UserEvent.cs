using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagement.DAL
{
  [Table("Event")]
  public class UserEvent
  {
    public UserEvent()
    {
    }

    public UserEvent(string name, string description, int layoutId)
    {
      Name = name;
      Description = description;
      LayoutId = layoutId;
    }

    public int Id { get; set; }

    [Required]
    [StringLength(120)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public int LayoutId { get; set; }
  }
}
