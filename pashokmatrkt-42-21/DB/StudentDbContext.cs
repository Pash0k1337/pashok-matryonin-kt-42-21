using Microsoft.EntityFrameworkCore;
using pashokmatrkt_42_21.Models;
using pashokmatrkt_42_21.DB.Configurations;

namespace pashokmatrkt_42_21.DB
{
    public class StudentDbContext : DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentCofiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        { 
        }
    }
} 
