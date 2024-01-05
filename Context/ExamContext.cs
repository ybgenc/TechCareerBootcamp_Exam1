using Microsoft.EntityFrameworkCore;
using TechCareerBootcamp_Exam1.Models;

namespace TechCareerBootcamp_Exam1.Context
{
    public class ExamContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Yusuf;Database=TechExam1Db;Trusted_Connection=true;");
        }


        public DbSet<BaseModel> BaseModels { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }

  
    


}
