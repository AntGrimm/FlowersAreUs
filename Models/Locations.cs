using System.Collections.Generic;

namespace FlowersAreUs.Models
{
  public class Locations
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string ManagerName { get; set; }
    public string PhoneNumber { get; set; }

    public List<Item> Items { get; set; } = new List<Item>();
  }
}