using Microsoft.EntityFrameworkCore;

namespace work2_examen
{
    public class testContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;user=Ivan;database=CompanyDB;port=3306;password=abcd123456abcd;CharSet=utf8;";

            optionsBuilder.UseMySql(connectionString);
        }
    }
}