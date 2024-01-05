using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerBootcamp_Exam1.Models
{
    [Table("Clients")]
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public int CompanyId { get; set; }    
        public Company Company { get; set; }
    }

    
}
