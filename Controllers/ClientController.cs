using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCareerBootcamp_Exam1.Context;
using TechCareerBootcamp_Exam1.Models;

namespace TechCareerBootcamp_Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ExamContext _context;
        public ClientController()
        {
            _context = new ExamContext();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Client = _context.Clients.Include(x => x.Company).ToList();
            return Ok(Client);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Client = _context.Clients.FirstOrDefault(r => r.Id == id);
            if (Client == null)
            {
                return NotFound();
            }
            return Ok(Client);
        }
        [HttpPost]
        public IActionResult CreateClient(Client Client)
        {
            _context.Clients.Add(Client);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateClient(Client Client)
        {
            _context.Clients.Update(Client);
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var Client = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (Client == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Remove(Client);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
