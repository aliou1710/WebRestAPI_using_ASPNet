using Microsoft.EntityFrameworkCore;

namespace WebAppAPI.DataModels
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options) : base(options)
        {
             
        }

        //cvd qu'on a une table student qui sera crée dans sql server database
        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
