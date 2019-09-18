using System.Linq;
using flowersareus;
using FlowersAreUs.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersAreUs.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class ItemController : ControllerBase
  {
    private DatabaseContext context;
    public ItemController(DatabaseContext _context)
    {
      this.context = _context;
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetOneItem(int id)
    {
      var item = context.Items.FirstOrDefault(i => i.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }

    // [HttpGet]
    // public ActionResult<Item> GetAllItems()
    // {
    //   var items = context.Items.OrderByDescending(flowersareus => flowersareus.DateOrdered);
    //   return items;
    // }
  }
}