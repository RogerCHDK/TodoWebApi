using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebApi.Models;

namespace TodoWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly TodoContext _db;
        public ItemController(TodoContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var items = _db.Items;
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Show(long Id)
        {
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound ();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Store(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Show), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long Id,Item item)
        {
            if (Id != item.Id)
            {
                return BadRequest();
            }
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long Id)
        {
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }

            _db.Items.Remove(item); 
            _db.SaveChanges();

            return NoContent();
        }
    }
}
