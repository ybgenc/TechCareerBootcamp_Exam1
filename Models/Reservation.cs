using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerBootcamp_Exam1.Models
{
    [Table("Reservations")]
    public class Reservation : BaseModel
    {
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int RoomId { get; set; } 
        public Room Room { get; set; }
    }
}
