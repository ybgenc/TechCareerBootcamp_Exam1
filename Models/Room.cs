using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerBootcamp_Exam1.Models
{
    [Table("Rooms")]
    public class Room : BaseModel
    {
        
        public string Name { get; set; }
    }
}
