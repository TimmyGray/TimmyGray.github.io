using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RestfulApiVisualCode.Models;
using System.Threading.Tasks;
using RestfulApiVisualCode.DataBaseContext;
using System;
 
namespace RestfulApiVisualCode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        EventsContext db;
        public EventsController(EventsContext context)
        {
            db = context;
            if (!db.Events.Any())
            {
                db.Events.Add(new Event { Nameofdevice = "SSL", Nameofasb = 4,Dateofevent = DateTime.Now.Date.ToShortDateString(), Isserios="no"});
                db.Events.Add(new Event { Nameofdevice = "Karrera", Nameofasb = 7,Dateofevent = DateTime.Now.Date.ToShortDateString(), Isserios="yes" });
                db.SaveChanges();
                
            }
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return await db.Events.ToListAsync();
        }
 
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            Event evnt = await db.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (evnt == null)
                return NotFound();
            return new ObjectResult(evnt);
        }
 
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Event>> Post(Event evnt)
        {
            if (evnt == null)
            {
                return BadRequest();
            }
 
            db.Events.Add(evnt);
            await db.SaveChangesAsync();
            return Ok(evnt);
        }
 
        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Event>> Put(Event evnt)
        {
            if (evnt == null)
            {
                return BadRequest();
            }
            if (!db.Events.Any(x => x.Id ==evnt.Id))
            {
                return NotFound();
            }
 
            db.Update(evnt);
            await db.SaveChangesAsync();
            return Ok(evnt);
        }
 
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> Delete(int id)
        {
            Event evnt = db.Events.FirstOrDefault(x => x.Id == id);
            if (evnt == null)
            {
                return NotFound();
            }
            db.Events.Remove(evnt);
            await db.SaveChangesAsync();
            return Ok(evnt);
        }
    }
}