using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenykEkzamen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenykEkzamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        public CalendarService _calendarService;

        public CalendarController(CalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet("Get all events")]
        public IActionResult GetAllEvents()
        {
            var allEvents = _calendarService.GetAllEvents();
            if (allEvents != null)
                return Ok(allEvents);
            return NoContent();
        }

        [HttpGet("Get event")]
        public IActionResult GetEvent(int id)
        {
            var e = _calendarService.GetEvent(id);
            if (e != null)
                return Ok(e);
            return NotFound();
        }

        [HttpGet("Find event")]
        public IActionResult FindEvent(string word)
        {
            var events = _calendarService.FindEvent(word);
            if (events != null)
                return Ok(events);
            return NoContent();
        }

        [HttpPost("Add event")]
        public IActionResult AddEvent([FromBody] CalendarVM e)
        {
            _calendarService.AddEvent(e);
            return Ok();
        }

        [HttpPut("Update event")]
        public IActionResult UpdateEvent(int id, [FromBody] CalendarVM e)
        {
            var n_event = _calendarService.UpdateEvent(id, e);
            return Ok(n_event);
        }

        [HttpDelete("Delete event")]
        public IActionResult DeleteEvent(int id)
        {
            _calendarService.DeleteEvent(id);
            return Ok();
        }
    }
}