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
        public IActionResult Get()
        {
            var reservations = _context.Reservations.Include(x => x.Client.Company).Include(x => x.Room).ToList();
            return Ok(reservations); 
        }

        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var reservation = _context.Reservations.Include(x => x.Client.Company).Include(x => x.Room).FirstOrDefault(x=>x.Id == id);
            if(reservation == null)
            {
                return BadRequest();
            }
            return Ok(reservation);
        }
        [HttpPost]
        public IActionResult CreateReservation(Reservation reservation)
        {
            if (DateTime.Parse(reservation.CheckIn) >= DateTime.Parse(reservation.CheckOut))
            {
                return BadRequest("Check your Check-In date");
            }
            Client client = _context.Clients.FirstOrDefault(x => x.Id == reservation.ClientId);
            Room room = _context.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
            if (room == null || client == null)
            {
                return NotFound("Client or room doesn't exist");
            }
            reservation.Client = client;
            reservation.Room = room;
            _context.Add(reservation);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateReservation(Reservation updatedReservation)
        {
            var GetReservation = _context.Reservations
                .Include(x => x.Client.Company)
                .Include(x => x.Room)
                .FirstOrDefault(x => x.Id == updatedReservation.Id);

            if (GetReservation == null)
            {
                return NotFound(); // Return NotFound if the reservation is not found
            }

            // Update properties of the existing reservation with the values from the input reservation
            GetReservation.CheckIn = updatedReservation.CheckIn;
            GetReservation.CheckOut = updatedReservation.CheckOut;
            GetReservation.ClientId = updatedReservation.ClientId;
            GetReservation.RoomId = updatedReservation.RoomId;

            // Check if CheckIn is before CheckOut
            if (DateTime.Parse(GetReservation.CheckIn) >= DateTime.Parse(GetReservation.CheckOut))
            {
                return BadRequest("Check your Check-In date");
            }

            // Save changes to the database
            _context.Update(GetReservation);
            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _context.Reservations
                .Include(x => x.Client.Company)
                .Include(x => x.Room)
                .FirstOrDefault(x => x.Id == id);
            _context.Remove(reservation);
            _context.SaveChanges();
            return Ok();
        }


    }
}
