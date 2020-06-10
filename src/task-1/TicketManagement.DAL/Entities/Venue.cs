using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagement.DAL
{
  [Table("Venue")]
  public class Venue
  {
    public Venue()
    {
    }

    public Venue(string description, string address, string phone)
    {
      Description = description;
      Address = address;
      Phone = phone;
    }

    public int Id { get; set; }

    [Required]
    [StringLength(120)]
    public string Description { get; set; }

    [Required]
    [StringLength(200)]
    public string Address { get; set; }

    [StringLength(30)]
    public string Phone { get; set; }
  }
}
