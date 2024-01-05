using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareerBootcamp_Exam1.Context;
using TechCareerBootcamp_Exam1.Models;

namespace TechCareerBootcamp_Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ExamContext _context;
        public RoomController()
        {
            _context = new ExamContext();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Rooms = _context.Rooms.ToList();
            return Ok(Rooms);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Room = _context.Rooms.FirstOrDefault(r => r.Id == id);
            if(Room == null)
            {
                return NotFound();
            }
            return Ok(Room);
        }
        [HttpPost]
        public IActionResult CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.Id == id);
            if(room == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Remove(room);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
