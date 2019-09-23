using System.Collections.Generic;
using System.Linq;
using flowersareus;
using FlowersAreUs.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersAreUs.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    private DatabaseContext context;
    public LocationsController(DatabaseContext _context)
    {
      this.context = _context;
    }

    [HttpPost]
    public ActionResult<Locations> CreateLocation([FromBody]Locations entry)
    {
      context.Locations.Add(entry);
      context.SaveChanges();
      return entry;
    }

    // GET /api/item
    [HttpGet]
    public ActionResult<IEnumerable<Locations>> GetAllLocations()
    {
      var locations = context.Locations.OrderByDescending(flowersareus => flowersareus.Id);
      return locations.ToList();
    }
  }
}