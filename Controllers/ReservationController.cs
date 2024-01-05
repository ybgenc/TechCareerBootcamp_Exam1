using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCareerBootcamp_Exam1.Context;
using TechCareerBootcamp_Exam1.Models;

namespace TechCareerBootcamp_Exam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ExamContext _context;
        public ReservationController()
        {
            _context = new ExamContext();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _context.Reservations.Include(x => x.Room).Include(x => x.Client.Company).ToList();

            return Ok(reservations);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reservation = _context.Reservations.Include(x => x.Room).Include(x => x.Client.Company).FirstOrDefault(x => x.Id == id);
            if (reservation == null) { return NotFound(); }

            return Ok(reservation);
        }
        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            if (reservation == null)
                return BadRequest();

            reservation.AddDate = DateTime.Now;
            Client client = _context.Clients.Find(reservation.Id);
            Room room = _context.Rooms.Find(reservation.Id);

            if (room == null || client == null) { return BadRequest(); }

            reservation.Room = room;
            reservation.Room.Id = room.Id;

            reservation.Client = client;
            reservation.Client.Id = client.Id;

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, reservation);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Reservation reservation)
        {
            var existingReservation = _context.Reservations.FirstOrDefault(r => r.Id == id);

            if (existingReservation == null) { return NotFound(); }

            Client client = _context.Clients.Find(reservation.Client.Id);
            Room room = _context.Rooms.Find(reservation.Room.Id);

            if (room == null || client == null) { return BadRequest(); }

            existingReservation.Room = room;
            existingReservation.Room.Id = room.Id;
            existingReservation.Client = client;
            existingReservation.Client.Id = client.Id;

            existingReservation.CheckIn = reservation.CheckIn;
            existingReservation.CheckOut = reservation.CheckOut;
            existingReservation.Room.Id = reservation.Room.Id;
            existingReservation.Client.Id = reservation.Client.Id;

            _context.Reservations.Update(existingReservation);
            _context.SaveChanges();

            return Ok(existingReservation);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(x => x.Id == id);

            if (reservation == null) { return NotFound(); }

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();

            return Ok(reservation);
        }

    }
}
