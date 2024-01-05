using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerBootcamp_Exam1.Models
{

    [Table("Company")]
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
