using Microsoft.EntityFrameworkCore;

namespace AngularCRUD.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=schoolMDB;User ID=root;Password=root; TrustServerCertificate= True");
        }
    }
}
