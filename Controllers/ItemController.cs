using System.Collections.Generic;
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

    [HttpGet("bySku/{sku}/")]
    public ActionResult<Item> GetOneItemBySku(int sku)
    {
      var item = context.Items.FirstOrDefault(i => i.Sku == sku);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }

    // GET /api/item
    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAllItems()
    {
      var items = context.Items.OrderByDescending(flowersareus => flowersareus.DateOrdered);
      return items.ToList();
    }

    // GET api/item/OutOfStock
    [HttpGet("OutOfStock")]
    public ActionResult<IEnumerable<Item>> GetOutOfStockItems()
    {
      var items = context.Items.OrderByDescending(flowersareus => flowersareus.NumberInStock == 0);
      return items.ToList();
    }

    [HttpPost]
    public ActionResult<Item> CreateItem([FromBody]Item entry)
    {
      context.Items.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpPut("{id}")]
    public ActionResult<Item> UpdateItem(int id, [FromBody]Item updateEntry)
    {
      context.Items.Update(updateEntry);
      context.SaveChanges();
      return updateEntry;
    }

    [HttpDelete("{id}")]
    public ActionResult<Item> DeleteItem(int id)
    {
      var item = context.Items.FirstOrDefault(i => i.Id == id);
      context.Items.Remove(item);
      context.SaveChanges();
      return item;
    }
  }
}