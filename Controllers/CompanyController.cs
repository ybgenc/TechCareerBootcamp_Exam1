using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareerBootcamp_Exam1.Context;
using TechCareerBootcamp_Exam1.Models;

namespace TechCareerBootcamp_Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ExamContext _context;
        public CompanyController()
        {
            _context = new ExamContext();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Company = _context.Company.ToList();
            return Ok(Company);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Company = _context.Company.FirstOrDefault(r => r.Id == id);
            if (Company == null)
            {
                return NotFound();
            }
            return Ok(Company);
        }
        [HttpPost]
        public IActionResult CreateCompany(Company Company)
        {
            _context.Company.Add(Company);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCompany(Company Company)
        {
            _context.Company.Update(Company);
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var Company = _context.Company.FirstOrDefault(x => x.Id == id);
            if (Company == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Remove(Company);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
